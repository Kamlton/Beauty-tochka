using System.ComponentModel.DataAnnotations;

namespace BeautyTochka.API.Models;

public class Service
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    [StringLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Duration { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Price { get; set; } = string.Empty;
}
