using System.ComponentModel.DataAnnotations;

namespace BeautyTochka.API.Models;

public class Review
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string AuthorName { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Text { get; set; } = string.Empty;

    [Range(1, 5)]
    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
