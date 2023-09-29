using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Portfolio.Web.Attributes;
using Portfolio.Web.Helpers;

namespace Portfolio.Web.Constraints;

public class CustomRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var controllerType = controller.ControllerType;
        //var baseType = controllerType.BaseType; // Controller'ın kalıtım aldığı sınıfın tipini verir

        if (controllerType.Namespace is not null && controllerType.Namespace.Contains("Areas"))
        {
            // Area adını almak için, namespace'i 'Areas' kelimesini böleceğiz
            var namespaceParts = controllerType.Namespace.Split('.');
            var areaIndex = Array.IndexOf(namespaceParts, "Areas");

            if (areaIndex >= 0 && areaIndex < namespaceParts.Length - 1)
            {
                var areaName = namespaceParts[areaIndex + 1].ToLower(); // "Areas" kelimesinin sonrasındaki bölüm area adını temsil eder
                var controllerName = RouteNameSpaceHelper.RouteNameToLowerAndReplace(controller.ControllerName);
                // küçük harfe çevrildi, türkçe karakter için harf düzenlemesi yapıldı ve s takısı eklendi

                var template = $"{areaName}/{controllerName}/{{action=Index}}/{{id?}}";

                foreach (var selector in controller.Selectors)
                {
                    selector.AttributeRouteModel = new AttributeRouteModel(new CustomRouteAttribute(areaName, template));
                }
            }
        }
    }
}