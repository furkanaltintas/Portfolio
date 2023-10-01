using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Web.Helpers;
using Portfolio.Web.ViewModels;

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
        IntroducePageViewModel introducePageViewModel = new()
        {
            Result = await _service.IntroduceService.GetIntroduceAsync(),
            GitHubRepoCount = await _service.IntroduceService.GitHubApiCount(),
            IsProjectActive = await _service.MenuService.IsMenuExistsAsync(
                ViewComponentNameRemoveHelper.ViewComponentNameRemove(nameof(PortfolioViewComponent)))
        };

        return View(introducePageViewModel);
    }
}