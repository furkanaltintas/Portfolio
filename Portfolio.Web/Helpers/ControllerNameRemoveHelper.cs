using Portfolio.Core.Entities.Enums;

namespace Portfolio.Web.Helpers;

public class ControllerNameRemoveHelper
{
    public static string ControllerNameRemove(string name)
    {
        name = name.Replace("Controller", "");
        return name;
    }
}