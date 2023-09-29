using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class AboutViewComponent : ViewComponent
{
    private readonly IService _service;

    public AboutViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.AboutService.GetAboutAsync();
        return View(result);
    }
}