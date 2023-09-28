using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class ContactGetAllDto : IDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Subject { get; set; } = null!;
}