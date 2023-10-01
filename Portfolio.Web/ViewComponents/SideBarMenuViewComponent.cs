using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;

namespace Portfolio.Web.ViewComponents
{
    public class SideBarMenuViewComponent : ViewComponent
    {
        private readonly IService _service;

        public SideBarMenuViewComponent(IService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _service.MenuService.GetAllByIsActiveMenuAsync();
            return View(result);
        }
    }
}
