using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class TestimonialController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.TestimonialService.GetAllTestimonialAsync();
        return View(result);
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.TestimonialService.DeleteTestimonialAsync(id);
        return RedirectToAction(nameof(Index));
    }
}