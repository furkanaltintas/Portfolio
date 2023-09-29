using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class HomeController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.MenuService.GetAllMenuAsync();
        return View(result);
    }

    public IActionResult MenuDetail()
    {
        return View();
    }
}