using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.DependencyResolvers.Autofac;
using Portfolio.DataAccess.Concrete.EntityFramework.Contexts;
using Portfolio.Entities.Concrete;
using Portfolio.Web.Constraints;
using Portfolio.Web.Events;
using Portfolio.Web.Filters;
using Portfolio.Web.Identity;
using Portfolio.Web.Localizations;
using Portfolio.Web.Validations;

namespace Portfolio.Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllersWithViews(options =>
        {
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan boş geçilmemelidir");
            options.Filters.Add<MvcExceptionFilter>();

            //options.Conventions.Add(new LowercaseAreaRouteConvention()); // Controller ismi buradan da yönetilebilinir
            //options.Conventions.Add(new LowercaseControllerRouteConvention());
            options.Conventions.Add(new CustomRouteConvention()); // path isimleri burada küçük harfe çevrildi
        });
    }

    public static ConfigureHostBuilder ConfigureAutofac(this ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        }));

        return host;
    }

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortfolioContext>(options =>
        {
            options
            .UseSqlServer(configuration.GetConnectionString("LocalDb"), options =>
            {
                options.MigrationsAssembly(assemblyName: "Portfolio.DataAccess"); // Migration sınıflarının bulunabileceği assembly yolunu belirtir.
            })
            .EnableSensitiveDataLogging();
            #region EnableSensitiveDataLogging
            // Entity Framework Core tarafından sağlanan bir seçenektir ve Entity Framework Core'un veritabanı işlemleri sırasında oluşan sorguların ve verilerin hassas bilgilerini (örneğin, veritabanı parolaları veya hassas kişisel bilgiler) kaydetmeye veya günlüğe almaya yarar.  Bu seçeneği kullanmak, genellikle geliştirme ve hata ayıklama aşamasında yararlıdır.Hassas bilgilerin günlüğe alınması, veritabanı işlemleri sırasında neyin olup bittiğini daha ayrıntılı bir şekilde anlamak ve hata ayıklamak için kullanışlıdır.Ancak, bu özellik prodüksiyon uygulamalarda etkinleştirilmemelidir, çünkü hassas bilgilerin günlüğe alınması güvenlik sorunlarına yol açabilir ve veri gizliliğini tehlikeye atabilir. Bu nedenle, EnableSensitiveDataLogging seçeneğini yalnızca geliştirme veya hata ayıklama amaçları için kullanmalı ve prodüksiyon uygulamalarında devre dışı bırakmalısınız.Bir uygulama prodüksiyon ortamında çalıştırıldığında, bu seçeneği kullanmamalısınız ve hassas bilgilerin günlüğe alınmamasını sağlamalısınız.Bu, uygulama güvenliğini ve kullanıcı verilerinin gizliliğini korumak için önemlidir.
            #endregion

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromSeconds(15);
            // Default değeri 30 dakikadır. 30 dakikada bir kontrol eder sistemi
        });

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromHours(1); // Token ömrünü 1 saat olarak ayarladık
        });

        services.AddIdentity<User, Role>(options =>
        {
            // User UserName and Email Options
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$"; // Kullanıcı adı oluşturulurken verilen karakterler (Karakterleri yan yana yazmamız gerekmektedir.)
            options.User.RequireUniqueEmail = true; // Bir kullanıcı kayıt olurken bu email adresinden sadece bir kayıt mı bulunsun ?


            // User Password Options
            options.Password.RequiredLength = 6; // Zorunlu uzunluk karakteri (Kaç karakter olsun ?) // Minimum 10 veya 12 vermemiz daha iyi olur güvenlik için
            options.Password.RequiredUniqueChars = 0; // Özel karakterlerden kaç tane olsun ? Unique karakterlerden kaç tane olması gerekiyor. (Özel karakterler !, ?)
            options.Password.RequireNonAlphanumeric = false; // Özel karakterler kullanılsın mı ? Özel karakterlerin kullanılmasını sağlıyor. (@, !, ?, $)
            options.Password.RequireLowercase = false; // Küçük harfler zorunlu olsun mu ?
            options.Password.RequireUppercase = false; // Büyük harfler zorunlu olsun mu ?
            options.Password.RequireDigit = false; // Rakam bulunsun mu ?

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3); // 3 dakika boyunca kilitli kalacak
            options.Lockout.MaxFailedAccessAttempts = 3; // 3 başarısız giriş yapıldığında kilitlenecek
        })
            .AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<PortfolioContext>();

        // Kullanıcıya özgü claims ekleme yöntemi
        services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsPrincipalFactory>();
    }

    public static void ConfigureCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            CookieBuilder cookieBuilder = new();
            cookieBuilder.Name = "PortfolioAppCookie";

            options.LoginPath = new PathString("/Account/Login"); // Oturum açmayı gerektiren bir sayfaya erişim sağlandığında yönlendirilecek sayfanın Url yolunu belirtir.

            options.LogoutPath = new PathString("/Account/LogOut"); // returnurl ile belirttikten sonra direkt olarak Member/LogOut kısmına gidecek ve çıkış işlemini yapacak

            options.AccessDeniedPath = new PathString("/Member/AccessDenied");

            options.Cookie = cookieBuilder;

            options.ExpireTimeSpan = TimeSpan.FromDays(60); // 60 Günlük ömür biçtik
            options.SlidingExpiration = true; // Kullanıcı 60 gün içerisinde giriş yapar ise cookie'nin ömrünü 60 gün daha uzatacak.
            // 30. gün giriş yaptıysa 60 gün daha uzatacak ömrünü 90 gün olacak
            // 60 gün boyunca hiç giriş yapmaz ise cookie silinecek

            var authenticationEvents = CookieAuthenticationEventsHandler.GetCookieAuthenticationEvents();
            options.Events = authenticationEvents;
        });
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache(); // Oturum verilerini bellekte saklamak için kullanılan örnek bir oturum mağazası
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(30); // Oturum süresi
            options.Cookie.HttpOnly = true;
        });
    }
}