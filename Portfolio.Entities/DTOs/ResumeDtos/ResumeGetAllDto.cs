using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class ResumeGetAllDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string SubTitle { get; set; } = null!;
    public string DateRange { get; set; } = null!;
}