using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.DTOs;
using Portfolio.Web.Areas.Admin.Controllers.Base;
using Portfolio.Web.Extensions;

namespace Portfolio.Web.Areas.Admin.Controllers;

[Authorize]
public class MenuController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Service.MenuService.GetAllMenuAsync();
        return this.ResponseView(result);
    }


    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(MenuCreateDto menuCreateDto)
    {
        var result = await Service.MenuService.MenuCreateAsync(menuCreateDto);
        return this.ResponseRedirectAction(result, nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var result = await Service.MenuService.GetMenuByIdTypeEntity<MenuUpdateDto>(id);
        result.Data.OldQueue = result.Data.Queue;
        result.Data.Queues = await Service.MenuService.MenuQueueAsync();
        return this.ResponseViewData(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(MenuUpdateDto menuUpdateDto)
    {
        var result = await Service.MenuService.MenuUpdateAsync(menuUpdateDto);
        return this.ResponseRedirectAction(result, nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var result = await Service.MenuService.MenuDeleteAsync(id);
        return this.ResponseRedirectAction(result, nameof(Index));
    }

    public async Task<IActionResult> UnDelete(int id)
    {
        var result = await Service.MenuService.MenuUnDeleteAsync(id);
        return this.ResponseRedirectAction(result, nameof(Index));
    }
}
