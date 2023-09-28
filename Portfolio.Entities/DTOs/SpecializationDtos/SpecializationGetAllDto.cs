using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class SpecializationGetAllDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string TotalProject { get; set; } = null!;
    public string IconName { get; set; } = null!;
}
