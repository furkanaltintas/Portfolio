using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Extensions;
using Portfolio.Web.Utils.Security.Captcha;

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        private const string CaptchaCode = nameof(CaptchaCode);
        private readonly IService _service;

        public ContactController(IService service)
        {
            _service = service;
        }

        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage()
        {
            int witdh = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(witdh, height, captchaCode);
            HttpContext.Session.SetString(CaptchaCode, result.CaptchaCode);
            Stream stream = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(stream, "image/png");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactCreateDto contactCreateDto)
        {
            if (ModelState.IsValid)
            {
                if (Captcha.ValidateCaptchaCode(contactCreateDto.CaptchaCode, HttpContext))
                {
                    await _service.ContactService.CreateContactAsync(contactCreateDto);
                    return this.ResponseRedirectAction(nameof(HomeController.Index), nameof(HomeController));
                }

                ModelState.AddModelError(string.Empty, "The captcha information you entered is incorrect");
            }

            return RedirectToAction("Index", "Home", contactCreateDto);
        }
    }
}