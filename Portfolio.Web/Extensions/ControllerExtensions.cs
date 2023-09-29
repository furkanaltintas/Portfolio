using Microsoft.AspNetCore.Mvc;

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

    public static IActionResult ResponseView<T>(
        this Controller controller,
        Core.Utilities.Results.Abstract.IDataResult<T> dataResult)
    {
        if (!dataResult.IsSuccess)
            return controller.NotFound();
        return controller.View(dataResult);
    }

    public static IActionResult ResponseViewData<T>(
    this Controller controller,
    Core.Utilities.Results.Abstract.IDataResult<T> dataResult)
    {
        if (!dataResult.IsSuccess)
            return controller.NotFound();
        return controller.View(dataResult.Data);
    }

}
