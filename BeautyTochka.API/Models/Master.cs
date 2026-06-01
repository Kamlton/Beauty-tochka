using System.ComponentModel.DataAnnotations;

namespace BeautyTochka.API.Models;

public class Master
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Position { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [StringLength(500)]
    public string? PhotoUrl { get; set; }

    public List<string> WorkPhotos { get; set; } = new List<string>();
}
