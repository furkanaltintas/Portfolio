using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Portfolio.Web.Constraints;

public class LowercaseControllerRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller) =>
        controller.ControllerName = controller.ControllerName.ToLower();
}