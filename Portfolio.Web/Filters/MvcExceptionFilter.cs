using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Portfolio.Core.Entities.Concrete;
using Portfolio.Core.Utilities.IoC;
using System.Data.SqlTypes;

namespace Portfolio.Web.Filters;

public class MvcExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _environment;
    private readonly IModelMetadataProvider _metadataProvider;
    private readonly ILogger? _logger;

    public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider)
    {
        _environment = environment;
        _metadataProvider = metadataProvider;
        _logger = ServiceTool.ServiceProvider?.GetService<ILogger>();
    }

    public void OnException(ExceptionContext context)
    {
        // Hangi ortamda olduğu kontrolü yapılıyor
        if(_environment.IsDevelopment())
        {
            context.ExceptionHandled = true; // Hata bizler tarafından ele alındığı için true yapıyoruz
            ErrorModel errorModel = new();
            switch (context.Exception)
            {
                case SqlNullValueException:
                    errorModel.Message = "Üzgünüz, işleminiz sırasında beklenmedik bir veritabanı hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
                    errorModel.Detail = context.Exception.Message;
                    _logger.LogError(context.Exception, context.Exception.Message);
                    break;

                case NullReferenceException:
                    errorModel.Message = "Üzgünüz, işleminiz sırasında beklenmedik bir null veriye rastlandı. Sorunu en kısa sürece çözeceğiz.";
                    errorModel.Detail = context.Exception.Message;
                    _logger.LogError(context.Exception, context.Exception.Message);
                    break;

                default:
                    errorModel.Message = "Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürece çözeceğiz.";
                    _logger.LogError(context.Exception, "Bu benim log hata mesajım!");
                    break;
            }

            ViewResult result = new() { ViewName = "Error" }; // Hata sayfasının ismi
            result.StatusCode = 500;
            result.ViewData = new(_metadataProvider, context.ModelState);
            result.ViewData.Add("ErrorModel", errorModel);
            context.Result = result;
        }
    }
}
