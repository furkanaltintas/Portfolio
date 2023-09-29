using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;

namespace Portfolio.Web.Areas.Admin.Controllers;

public class ResumeController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.ResumeService.GetAllResumeAsync();
        return View(result);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ResumeCreateDto resumeCreateDto)
    {
        var result = await Service.ResumeService.CreateResumeAsync(resumeCreateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await Service.ResumeService.GetResumeByIdAsync(id);
        return View(result.Data);
    }


    [HttpPost]
    public async Task<IActionResult> Update(ResumeUpdateDto resumeUpdateDto)
    {
        var result = await Service.ResumeService.UpdateResumeAsync(resumeUpdateDto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Remove(int id)
    {
        var result = await Service.ResumeService.DeleteResumeAsync(id);
        return RedirectToAction(nameof(Index));
    }
}