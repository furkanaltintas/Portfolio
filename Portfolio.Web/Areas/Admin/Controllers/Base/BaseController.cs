using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Web.Attributes;

namespace Portfolio.Web.Areas.Admin.Controllers.Base;

[Area("Admin")]
public class BaseController : Controller
{
    protected IService Service => _service ??= HttpContext.RequestServices.GetService<IService>()!;
    private IService? _service;
}