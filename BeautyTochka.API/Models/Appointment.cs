using System.ComponentModel.DataAnnotations;

namespace BeautyTochka.API.Models;

public enum AppointmentStatus
{
    New,
    Confirmed,
    Rejected
}

public class Appointment
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ClientName { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ServiceName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string MasterName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Comment { get; set; }

    public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;

    public AppointmentStatus Status { get; set; } = AppointmentStatus.New;
}
