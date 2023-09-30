using Microsoft.AspNetCore.Authentication.Cookies;

namespace Portfolio.Web.Events;

public class CookieAuthenticationEventsHandler
{
    public static CookieAuthenticationEvents GetCookieAuthenticationEvents()
    {
        return new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                if (context.Request.Path.StartsWithSegments("/Admin"))
                    context.Response.Redirect("/");
                else
                    context.Response.Redirect(context.RedirectUri);
                return Task.CompletedTask;
            }
        };
    }
}
