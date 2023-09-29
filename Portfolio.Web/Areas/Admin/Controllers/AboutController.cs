using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class AboutController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.AboutService.GetAboutAsync();
        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(AboutCreateDto aboutCreateDto)
    {
        var result = await Service.AboutService.CreateAboutAsync(aboutCreateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await Service.AboutService.GetAboutByIdAsync(id);
        return View(result.Data);
    }


    [HttpPost]
    public async Task<IActionResult> Update(AboutGetDto aboutGetDto)
    {
        //var result = await Service.AboutService.UpdateAboutAsync(aboutGetDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.AboutService.DeleteAboutAsync(id);
        return RedirectToAction(nameof(Index));
    }
}