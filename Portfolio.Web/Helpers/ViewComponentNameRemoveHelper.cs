namespace Portfolio.Web.Helpers;

public static class ViewComponentNameRemoveHelper
{
    private const string VIEW_COMPONENT = "ViewComponent";

    public static string ViewComponentNameRemove(string viewComponentName)
    {
        viewComponentName = viewComponentName.Replace(VIEW_COMPONENT, string.Empty);
        return viewComponentName;
    }
}