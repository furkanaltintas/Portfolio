using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class SpecializationViewComponent : ViewComponent
{
    private readonly IService _service;

    public SpecializationViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.SpecializationService.GetAllActiveSpecializationAsync();
        return View(result);
    }
}