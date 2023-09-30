namespace Portfolio.Web.Middlewares
{
    public class MaintenanceModeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _maintenanceMode;
        private readonly IConfiguration _configuration;

        public MaintenanceModeMiddleware(RequestDelegate next, bool maintenanceMode, IConfiguration configuration)
        {
            _next = next;
            _maintenanceMode = maintenanceMode;
            _configuration = configuration;
        }


        public async Task Invoke(HttpContext context)
        {
            bool maintenanceMode = _configuration.GetValue<bool>("MaintenanceMode");

            // !context.Request.Path.StartsWithSegments("/maintenance") => Mevcut isteğin 'maintenance' yolunda mı olduğunu kontrol ediyoruz.
            if (maintenanceMode && !context.Request.Path.StartsWithSegments("/maintenance") && !context.User.Identity!.IsAuthenticated)
            {
                context.Response.Redirect("/maintenance");
                return;
            }

            if (!maintenanceMode && context.Request.Path.StartsWithSegments("/maintenance") && !context.User.Identity!.IsAuthenticated)
            {
                context.Response.Redirect("/");
                return;
            }

            await _next(context);
        }
    }
}

// Bakım modunu kontrol eder ve yetkisiz kullanıcılara 503 hizmet kullanılamaz yanıtı verir.
