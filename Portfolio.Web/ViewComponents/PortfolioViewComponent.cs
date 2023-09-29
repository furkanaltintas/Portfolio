using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents;

public class PortfolioViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}