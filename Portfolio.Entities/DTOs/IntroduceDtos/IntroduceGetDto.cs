using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;

public class IntroduceGetDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public short ExperiencePeriod { get; set; }
    public string ExperienceContent { get; set; } = null!;

    public short ProjectCount { get; set; }
    public string ProjectContent { get; set; } = null!;
}
