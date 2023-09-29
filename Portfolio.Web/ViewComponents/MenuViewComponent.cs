using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class MenuViewComponent : ViewComponent
{
    private readonly IService _service;

    public MenuViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.MenuService.GetAllMenuAsync();
        return View(result);
    }
}