using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Areas.Admin.ViewComponents
{
    public class AdminMaintenanceViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public AdminMaintenanceViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            bool maintenanceMode = _configuration.GetValue<bool>("MaintenanceMode");
            return View(maintenanceMode);
        }
    }
}