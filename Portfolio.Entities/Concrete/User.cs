using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entities.Concrete;

public class User : IdentityUser
{
    public string Picture { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Degree { get; set; } = null!;
    public string Address { get; set; } = null!;
}