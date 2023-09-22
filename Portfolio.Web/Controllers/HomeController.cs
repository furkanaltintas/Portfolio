using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
