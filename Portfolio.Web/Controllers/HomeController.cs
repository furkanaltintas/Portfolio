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
}