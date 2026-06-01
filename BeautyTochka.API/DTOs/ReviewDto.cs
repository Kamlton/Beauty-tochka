namespace BeautyTochka.API.DTOs;

public class ReviewDto
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ReviewCreateDto
{
    public string AuthorName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; }
}
