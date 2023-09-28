using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class AboutGetDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }
}