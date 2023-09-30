using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

[Authorize]
public class SkillController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.SkillService.GetAllSkillAsync();
        return View(result);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(SkillCreateDto skillCreateDto)
    {
        var result = await Service.SkillService.CreateSkillAsync(skillCreateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await Service.SkillService.GetSkillByIdAsync(id);
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
        var result = await Service.SkillService.DeleteSkillAsync(id);
        return RedirectToAction(nameof(Index));
    }
}