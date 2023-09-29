using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class SkillViewComponent : ViewComponent
{
    private readonly IService _service;

    public SkillViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.SkillService.GetAllActiveSkillAsync();
        return View(result);
    }
}