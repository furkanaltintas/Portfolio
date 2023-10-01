namespace Portfolio.Web.Helpers;

public class ControllerNameRemoveHelper
{
    private const string CONTROLLER = "Controller";
    public static string ControllerNameRemove(string controllerName)
    {
        controllerName = controllerName.Replace(CONTROLLER, string.Empty);
        return controllerName;
    }
}