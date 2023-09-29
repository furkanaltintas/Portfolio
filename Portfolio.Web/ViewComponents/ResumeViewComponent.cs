using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class ResumeViewComponent : ViewComponent
{
    private readonly IService _service;

    public ResumeViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.ResumeService.GetAllActiveResumeAsync();
        return View(result);
    }
}