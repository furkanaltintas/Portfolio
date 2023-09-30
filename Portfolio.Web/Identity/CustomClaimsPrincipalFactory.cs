using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Portfolio.Entities.Concrete;
using System.Security.Claims;

namespace Portfolio.Web.Identity;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
{
    public CustomClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        identity.AddClaim(new Claim("Profile", user.Picture));


        return identity;
    }
}