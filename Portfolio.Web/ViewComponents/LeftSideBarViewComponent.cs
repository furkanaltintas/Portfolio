using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents;

public class LeftSideBarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}