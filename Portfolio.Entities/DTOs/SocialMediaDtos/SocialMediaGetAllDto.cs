using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.DTOs;
public class SocialMediaGetAllDto : IDto
{
    public string Name { get; set; } = null!;
    public string IconName { get; set; } = null!;
    public string Link { get; set; } = null!;
}