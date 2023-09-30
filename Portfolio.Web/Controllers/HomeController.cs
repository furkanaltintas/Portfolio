using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.Controllers;

public class HomeController : Controller
{
    private readonly IService _service;

    public HomeController(IService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.MenuService.GetAllByIsActiveMenuAsync();
        return View(result);
    }

    [Route("maintenance")]
    public IActionResult Maintenance()
    {
        // Bakıma gidebilmek için zorunlu bakım moduna girişi açmamız gerekiyor. Veritabanı üzerinden giriş yapılabilinir.

        if (HttpContext.User.Identity.IsAuthenticated) // Yetkili kişi giriş yapamaz
            return RedirectToAction(nameof(Index));
        else
            return View();
    }

    [HttpPost]
    [Route("cvdownload")]
    public IActionResult CvAttachmentDownload()
    {
        return View();
    }
}