using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Core.Helpers.Html;

public static class HtmlActiveHelpers
{
    public static string IsActive(this IHtmlHelper html, string controller, string action)
    {
        return
            html.ViewContext.RouteData.Values["controller"]!.ToString() == controller
            &&
            html.ViewContext.RouteData.Values["action"]!.ToString() == action
            ?
            "active" : "";
    }

    public static string IsActive(this IHtmlHelper html, string area, string controller, string action)
    {
        return
            html.ViewContext.RouteData.Values["area"]?.ToString() == area
            &&
            html.ViewContext.RouteData.Values["controller"]!.ToString() == controller
            &&
            html.ViewContext.RouteData.Values["action"]!.ToString() == action
            ?
            "active" : "";
    }
}