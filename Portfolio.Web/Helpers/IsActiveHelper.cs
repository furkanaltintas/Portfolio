namespace Portfolio.Web.Helpers;

public static class IsActiveHelper
{
    public static string GetIsActiveStatus(bool isActive) =>
        isActive ? "Aktif" : "Aktif Değil";


    public static string MenuIsActive(string controllerName, string menuControllerName)
    {
        return controllerName == menuControllerName ? "active" : string.Empty;
    }

    public static string GetIsRemoveStatus(bool isRemove) =>
        isRemove ? "Silindi" : "Silinmedi";
}