namespace Portfolio.Entities.DTOs;

public class ContactCreateDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string CaptchaCode { get; set; } = null!;

    public bool IsItOnAir { get; set; } = false; // Yayında Mı ?
}