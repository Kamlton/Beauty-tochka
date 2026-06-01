using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTochka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MastersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MastersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MasterDto>>> GetAll()
    {
        var masters = await _unitOfWork.Masters.GetAllAsync();
        var dto = masters.Select(m => new MasterDto
        {
            Id = m.Id,
            FullName = m.FullName,
            Position = m.Position,
            Description = m.Description,
            Email = m.Email,
            PhoneNumber = m.PhoneNumber,
            PhotoUrl = m.PhotoUrl,
            WorkPhotos = m.WorkPhotos
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MasterDto>> Get(int id)
    {
        var master = await _unitOfWork.Masters.GetByIdAsync(id);
        if (master == null) return NotFound();
        return Ok(new MasterDto
        {
            Id = master.Id,
            FullName = master.FullName,
            Position = master.Position,
            Description = master.Description,
            Email = master.Email,
            PhoneNumber = master.PhoneNumber,
            PhotoUrl = master.PhotoUrl,
            WorkPhotos = master.WorkPhotos
        });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<MasterDto>> Create(MasterCreateDto dto)
    {
        var master = new Master
        {
            FullName = dto.FullName,
            Position = dto.Position,
            Description = dto.Description,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            PhotoUrl = dto.PhotoUrl,
            WorkPhotos = dto.WorkPhotos ?? new List<string>()
        };
        await _unitOfWork.Masters.AddAsync(master);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = master.Id }, new MasterDto
        {
            Id = master.Id,
            FullName = master.FullName,
            Position = master.Position,
            Description = master.Description,
            Email = master.Email,
            PhoneNumber = master.PhoneNumber,
            PhotoUrl = master.PhotoUrl,
            WorkPhotos = master.WorkPhotos
        });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, MasterCreateDto dto)
    {
        var master = await _unitOfWork.Masters.GetByIdAsync(id);
        if (master == null) return NotFound();
        master.FullName = dto.FullName;
        master.Position = dto.Position;
        master.Description = dto.Description;
        master.Email = dto.Email;
        master.PhoneNumber = dto.PhoneNumber;
        master.PhotoUrl = dto.PhotoUrl;
        master.WorkPhotos = dto.WorkPhotos ?? new List<string>();
        _unitOfWork.Masters.Update(master);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var master = await _unitOfWork.Masters.GetByIdAsync(id);
        if (master == null) return NotFound();
        _unitOfWork.Masters.Delete(master);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
