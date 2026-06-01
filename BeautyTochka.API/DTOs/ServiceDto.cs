namespace BeautyTochka.API.DTOs;

public class ServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
}

public class ServiceCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
}
