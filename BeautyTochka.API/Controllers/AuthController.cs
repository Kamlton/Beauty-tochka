using System.Security.Cryptography;
using System.Text;
using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using BeautyTochka.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTochka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public AuthController(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<TokenDto>> Register(RegisterDto dto)
    {
        var existing = (await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email)).FirstOrDefault();
        if (existing != null)
            return BadRequest(new { message = "Пользователь с таким email уже существует" });

        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = HashPassword(dto.Password),
            Role = UserRole.User
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveAsync();

        var token = _jwtService.GenerateToken(user);
        return Ok(new TokenDto
        {
            Token = token,
            User = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            }
        });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<TokenDto>> Login(LoginDto dto)
    {
        var user = (await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email)).FirstOrDefault();
        if (user == null || user.PasswordHash != HashPassword(dto.Password))
            return Unauthorized(new { message = "Неверный email или пароль" });

        var token = _jwtService.GenerateToken(user);
        return Ok(new TokenDto
        {
            Token = token,
            User = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            }
        });
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserDto>> Me()
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
            return Unauthorized();

        var user = (await _unitOfWork.Users.FindAsync(u => u.Email == email)).FirstOrDefault();
        if (user == null) return NotFound();

        return Ok(new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role
        });
    }

    [HttpPost("seed-admin")]
    [AllowAnonymous]
    public async Task<IActionResult> SeedAdmin()
    {
        var existing = (await _unitOfWork.Users.FindAsync(u => u.Email == "admin@beautytochka.ru")).FirstOrDefault();
        if (existing != null)
            return Ok(new { message = "Админ уже существует" });

        var admin = new User
        {
            FullName = "Администратор",
            Email = "admin@beautytochka.ru",
            PasswordHash = HashPassword("Admin123!"),
            Role = UserRole.Admin
        };

        await _unitOfWork.Users.AddAsync(admin);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = "Админ создан: admin@beautytochka.ru / Admin123!" });
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
}
