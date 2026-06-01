using BeautyTochka.API.Models;

namespace BeautyTochka.API.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public string MasterName { get; set; } = string.Empty;
    public string? Comment { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
}

public class AppointmentCreateDto
{
    public string ClientName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public string MasterName { get; set; } = string.Empty;
    public string? Comment { get; set; }
}
