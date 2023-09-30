using System.Security.Claims;

namespace Portfolio.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    // ClaimsPrincipal => Mevcut kullanıcımıza karşılık gelir
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindAll(claimType)?.Select(c => c.Value).ToList();
        return result;
    }


    public static string? Claim(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var result = claimsPrincipal?.FindFirst(claimType)?.Value;
        return result;
    }


    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }
}