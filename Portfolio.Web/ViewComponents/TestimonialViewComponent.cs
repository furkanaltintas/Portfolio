using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class TestimonialViewComponent : ViewComponent
{
    private readonly IService _service;

    public TestimonialViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.TestimonialService.GetAllActiveTestimonialAsync();
        return View(result);
    }
}