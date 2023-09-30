using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Helpers;

namespace Portfolio.Web.Controllers
{
    [Route("/vettel")]
    public class AccountController : Controller
    {
        private readonly IService _service;

        public AccountController(IService service)
        {
            _service = service;
        }

        [Route("login")]
        public IActionResult Login() => View();


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, string? returnUrl = null)
        {
            returnUrl ??= Url.Action(nameof(HomeController.Index), ControllerNameRemoveHelper.ControllerNameRemove(nameof(HomeController)), new { area = "Admin" });

            var result = await _service.UserService.UserLoginAsync(userLoginDto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }

            return Redirect(returnUrl!);
        }


        [Route("logout")]
        public async Task Logout()
        {
            await _service.UserService.UserLogoutAsync();
        }
    }
}
