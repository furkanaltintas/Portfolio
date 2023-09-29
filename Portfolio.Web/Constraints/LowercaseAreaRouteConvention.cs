using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Portfolio.Web.Constraints
{
    public class LowercaseAreaRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (controller.RouteValues.ContainsKey("area")) // controller.ControllerType.FullName.Contains("Areas") (diğer yol)
                {
                    //controller.ControllerName = controller.ControllerName.ToLower();
                    controller!.RouteValues["area"] = controller.RouteValues["area"]!.ToLower();
                }
            }
        }
    }
}