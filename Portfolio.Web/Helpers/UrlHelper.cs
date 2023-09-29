namespace Portfolio.Web.Helpers;

public static class UrlHelper
{
    public static string GetApplicationPageUrl(this HttpContext httpContext)
    {
        string applicationPageUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
        return applicationPageUrl;
    }


    public static string GetApplicationPageUrl(this HttpContext httpContext, string name)
    {
        string applicationPageUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{name}";
        return applicationPageUrl;
    }
}