using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class TestimonialGetAllDto : IDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Degree { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
}