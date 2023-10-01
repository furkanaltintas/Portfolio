using Microsoft.AspNetCore.Authentication.Cookies;

namespace Portfolio.Web.Events;

public class CookieAuthenticationEventsHandler
{
    public static CookieAuthenticationEvents GetCookieAuthenticationEvents()
    {
        return new CookieAuthenticationEvents
        {
            // Kullanıcının oturum açma gereksinimini karşılayamadığı durumda nereye yönlendirileceğini belirlemektedir
            OnRedirectToLogin = context =>
            {
                // context.Request.Path => Eğer istemci tarafından yapılan istek 'Admin' ile başlıyorsa kullanıcıyı ana sayfaya yönlendirecek
                if (context.Request.Path.StartsWithSegments("/Admin"))
                    context.Response.Redirect("/");
                else
                    context.Response.Redirect(context.RedirectUri); // Aksi durumda, kullanıcıyı oturum açma sayfasına yönlendirir
                return Task.CompletedTask;
            }
        };
    }
}

/*
 Kodu kullanma amacım

"/Admin" yolu üzerindeki sayfalara giriş yapmaya çalışan kullanıcılara erişimini engellemek için kullandım.
Admin yolu üzerinde ki bir sayfaya yetkisiz kullanıcı gitmeye çalıştığında AccessDenied yapısı tetiklendiği için Login sayfasına yönlendirmekteydi.
Login yolunu bulmaması ve giriş yapmaya çalışmaması için bir güvenlik işlemi yapıldı
 */