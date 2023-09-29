namespace Portfolio.Web.Helpers
{
    public static class RouteNameSpaceHelper
    {
        public static string RouteNameToLowerAndReplace(string name)
        {
            return name
                .ToLower()
                .Replace("ı", "i") + "s";
        }
    }
}