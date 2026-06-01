namespace BeautyTochka.API.DTOs;

public class MasterDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
    public List<string> WorkPhotos { get; set; } = new List<string>();
}

public class MasterCreateDto
{
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
    public List<string> WorkPhotos { get; set; } = new List<string>();
}
