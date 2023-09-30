using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

[Authorize]
public class SpecializationController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.SpecializationService.GetAllSpecializationAsync();
        return View(result);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(SpecializationCreateDto specializationCreateDto)
    {
        var result = await Service.SpecializationService.CreateSpecializationAsync(specializationCreateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        //var result = await Service.SpecializationService.GetIntroduceByIdAsync(id);
        //return View(result.Data);
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Update(IntroduceGetDto introduceGetDto)
    {
        var result = await Service.IntroduceService.UpdateIntroduceAsync(introduceGetDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.SpecializationService.DeleteSpecializationAsync(id);
        return RedirectToAction(nameof(Index));
    }
}