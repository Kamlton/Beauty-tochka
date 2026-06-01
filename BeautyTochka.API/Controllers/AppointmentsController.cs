using BeautyTochka.API.DTOs;
using BeautyTochka.API.Models;
using BeautyTochka.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTochka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync();
        var dto = appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            ClientName = a.ClientName,
            PhoneNumber = a.PhoneNumber,
            ServiceName = a.ServiceName,
            MasterName = a.MasterName,
            Comment = a.Comment,
            AppointmentDate = a.AppointmentDate,
            Status = a.Status
        });
        return Ok(dto);
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> Search([FromQuery] string phone)
    {
        var appointments = await _unitOfWork.Appointments.FindAsync(a => a.PhoneNumber == phone);
        var dto = appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            ClientName = a.ClientName,
            PhoneNumber = a.PhoneNumber,
            ServiceName = a.ServiceName,
            MasterName = a.MasterName,
            Comment = a.Comment,
            AppointmentDate = a.AppointmentDate,
            Status = a.Status
        });
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<AppointmentDto>> Get(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        return Ok(new AppointmentDto
        {
            Id = appointment.Id,
            ClientName = appointment.ClientName,
            PhoneNumber = appointment.PhoneNumber,
            ServiceName = appointment.ServiceName,
            MasterName = appointment.MasterName,
            Comment = appointment.Comment,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status
        });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<AppointmentDto>> Create(AppointmentCreateDto dto)
    {
        var appointment = new Appointment
        {
            ClientName = dto.ClientName,
            PhoneNumber = dto.PhoneNumber,
            ServiceName = dto.ServiceName,
            MasterName = dto.MasterName,
            Comment = dto.Comment,
            AppointmentDate = DateTime.UtcNow,
            Status = AppointmentStatus.New
        };
        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get), new { id = appointment.Id }, new AppointmentDto
        {
            Id = appointment.Id,
            ClientName = appointment.ClientName,
            PhoneNumber = appointment.PhoneNumber,
            ServiceName = appointment.ServiceName,
            MasterName = appointment.MasterName,
            Comment = appointment.Comment,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status
        });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, AppointmentCreateDto dto)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        appointment.ClientName = dto.ClientName;
        appointment.PhoneNumber = dto.PhoneNumber;
        appointment.ServiceName = dto.ServiceName;
        appointment.MasterName = dto.MasterName;
        appointment.Comment = dto.Comment;
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpPatch("{id}/status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] AppointmentStatus status)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        appointment.Status = status;
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        _unitOfWork.Appointments.Delete(appointment);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
