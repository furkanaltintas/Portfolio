using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class MaintenanceController : Controller
{
    private readonly IConfiguration _configuration;

    public MaintenanceController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult ToggleMaintenanceMode()
    {
        bool maintenanceMode = _configuration.GetValue<bool>("MaintenanceMode");
        maintenanceMode = !maintenanceMode;

        // MaintenanceMode değerini güncelle
        _configuration["MaintenanceMode"] = maintenanceMode.ToString();

        string referer = HttpContext.Request.Headers["Referer"].ToString(); // Örn: http://localhost:5257/admin/contacts
        // HttpPost işlemi yapmadan önce bulunduğumuz sayfayı almak için kullanılır.
        // Referer başlığı, isteği yapan tarayıcının bulunduğu sayfanın URL'sini içerir.


        return Redirect(referer);
    }
}