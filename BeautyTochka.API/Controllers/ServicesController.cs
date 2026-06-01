using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTochka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ServicesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAll()
    {
        var services = await _unitOfWork.Services.GetAllAsync();
        var dto = services.Select(s => new ServiceDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Category = s.Category,
            Duration = s.Duration,
            Price = s.Price
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceDto>> Get(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null) return NotFound();
        return Ok(new ServiceDto
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Category = service.Category,
            Duration = service.Duration,
            Price = service.Price
        });
    }

    [HttpGet("categories/{category}")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetByCategory(string category)
    {
        var services = await _unitOfWork.Services.FindAsync(s => s.Category == category);
        var dto = services.Select(s => new ServiceDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Category = s.Category,
            Duration = s.Duration,
            Price = s.Price
        });
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ServiceDto>> Create(ServiceCreateDto dto)
    {
        var service = new Service
        {
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            Duration = dto.Duration,
            Price = dto.Price
        };
        await _unitOfWork.Services.AddAsync(service);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = service.Id }, new ServiceDto
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Category = service.Category,
            Duration = service.Duration,
            Price = service.Price
        });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, ServiceCreateDto dto)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null) return NotFound();
        service.Name = dto.Name;
        service.Description = dto.Description;
        service.Category = dto.Category;
        service.Duration = dto.Duration;
        service.Price = dto.Price;
        _unitOfWork.Services.Update(service);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null) return NotFound();
        _unitOfWork.Services.Delete(service);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
