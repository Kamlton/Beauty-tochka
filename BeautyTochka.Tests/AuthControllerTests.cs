using BeautyTochka.API.Controllers;
using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using BeautyTochka.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BeautyTochka.Tests;

public class AuthControllerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRepository<User>> _userRepoMock;
    private readonly Mock<IJwtService> _jwtServiceMock;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepoMock = new Mock<IRepository<User>>();
        _unitOfWorkMock.Setup(u => u.Users).Returns(_userRepoMock.Object);

        _jwtServiceMock = new Mock<IJwtService>();
        _jwtServiceMock.Setup(j => j.GenerateToken(It.IsAny<User>())).Returns("fake-jwt-token");

        _controller = new AuthController(_unitOfWorkMock.Object, _jwtServiceMock.Object);
    }

    [Fact]
    public async Task Register_NewUser_ReturnsToken()
    {
        // Arrange
        _userRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(new List<User>());
        _userRepoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.SaveAsync()).ReturnsAsync(1);

        var dto = new RegisterDto { FullName = "Иван", Email = "ivan@test.ru", Password = "password123" };

        // Act
        var result = await _controller.Register(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tokenDto = Assert.IsType<TokenDto>(okResult.Value);
        Assert.Equal("fake-jwt-token", tokenDto.Token);
    }

    [Fact]
    public async Task Register_ExistingUser_ReturnsBadRequest()
    {
        // Arrange
        var existing = new List<User> { new User { Email = "ivan@test.ru" } };
        _userRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(existing);

        var dto = new RegisterDto { FullName = "Иван", Email = "ivan@test.ru", Password = "password123" };

        // Act
        var result = await _controller.Register(dto);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsToken()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            FullName = "Иван",
            Email = "ivan@test.ru",
            PasswordHash = "EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F", // SHA256 of "password123"
            Role = UserRole.User
        };
        _userRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(new List<User> { user });

        var dto = new LoginDto { Email = "ivan@test.ru", Password = "password123" };

        // Act
        var result = await _controller.Login(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var tokenDto = Assert.IsType<TokenDto>(okResult.Value);
        Assert.Equal("fake-jwt-token", tokenDto.Token);
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        _userRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<User, bool>>>()))
            .ReturnsAsync(new List<User>());

        var dto = new LoginDto { Email = "ivan@test.ru", Password = "wrongpassword" };

        // Act
        var result = await _controller.Login(dto);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result.Result);
    }
}
