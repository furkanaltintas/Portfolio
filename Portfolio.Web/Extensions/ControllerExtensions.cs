using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Web.Helpers;

namespace Portfolio.Web.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ResponseRedirectAction(
        this Controller controller,
        Core.Utilities.Results.Abstract.IResult result,
        string actionName,
        string? controllerName = null)
    {
        if (!result.IsSuccess)
            return controller.NotFound();

        if (string.IsNullOrWhiteSpace(controllerName))
            return controller.RedirectToAction(actionName);
        return controller.RedirectToAction(actionName, controllerName);
    }

    public static IActionResult ResponseRedirectAction(
        this Controller controller,
        string actionName,
        string? controllerName = null)
    {
        if (string.IsNullOrWhiteSpace(controllerName))
            return controller.RedirectToAction(actionName);
        return controller.RedirectToAction(actionName, ControllerNameRemoveHelper.ControllerNameRemove(controllerName));
    }

    // Result yapısını dönen
    public static IActionResult ResponseView<T>(
        this Controller controller,
        IDataResult<T> dataResult)
    {
        if (!dataResult.IsSuccess)
            return controller.NotFound();
        return controller.View(dataResult);
    }

    // Direkt olarak datayı dönen
    public static IActionResult ResponseViewData<T>(
    this Controller controller,
    IDataResult<T> dataResult)
    {
        if (!dataResult.IsSuccess)
            return controller.NotFound();
        return controller.View(dataResult.Data);
    }

}
