﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents;

public class IntroduceViewComponent : ViewComponent
{
    private readonly IService _service;

    public IntroduceViewComponent(IService service)
    {
        _service = service;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.IntroduceService.GetIntroduceAsync();

        return View(result);
    }
}