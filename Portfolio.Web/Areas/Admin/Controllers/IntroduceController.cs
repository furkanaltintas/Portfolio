using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class IntroduceController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.IntroduceService.GetIntroduceAsync();
        return View(result);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(IntroduceCreateDto introduceCreateDto)
    {
        var result = await Service.IntroduceService.CreateIntroduceAsync(introduceCreateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await Service.IntroduceService.GetIntroduceByIdAsync(id);
        return View(result.Data);
    }


    [HttpPost]
    public async Task<IActionResult> Update(IntroduceGetDto introduceGetDto)
    {
        var result = await Service.IntroduceService.UpdateIntroduceAsync(introduceGetDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.IntroduceService.DeleteIntroduceAsync(id);
        return RedirectToAction(nameof(Index));
    }
}