using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Portfolio.Web.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class CustomRouteAttribute : RouteAttribute, IRouteTemplateProvider
{
    private readonly string _areaName;

    public CustomRouteAttribute(string areaName, string template) : base(template)
    {
        _areaName = areaName;
    }

    public string Area => _areaName;
}