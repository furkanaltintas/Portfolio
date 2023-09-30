namespace Portfolio.Entities.DTOs;

public class UserProfileDto
{
    public string Picture { get; set; } = null!;
    public string Degree { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public IEnumerable<SocialMediaGetAllDto> SocialMediaGetAllDto { get; set; } = Enumerable.Empty<SocialMediaGetAllDto>();
}