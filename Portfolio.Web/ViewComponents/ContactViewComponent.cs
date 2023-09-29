using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Web.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IService _service;

        public ContactViewComponent(IService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hasContact = await _service.ContactService.HasContactAsync();
            ContactCreateDto contactAddDto = new() { IsItOnAir = hasContact };
            return View(contactAddDto);
        }
    }
}
