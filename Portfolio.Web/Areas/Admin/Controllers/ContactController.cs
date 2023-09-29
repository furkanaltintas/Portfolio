using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class ContactController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.ContactService.GetAllContactAsync();
        return View(result);
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.ContactService.DeleteContactAsync(id);
        return RedirectToAction(nameof(Index));
    }
}