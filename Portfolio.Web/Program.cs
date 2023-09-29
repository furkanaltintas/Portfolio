using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Core.DependencyResolvers;
using Portfolio.Core.Extensions;
using Portfolio.Core.Utilities.IoC;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete;
using Portfolio.DataAccess.Concrete.EntityFramework.Contexts;
using Portfolio.Web.Constraints;
using Portfolio.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    //options.Conventions.Add(new LowercaseAreaRouteConvention()); // Controller ismi buradan da yönetilebilinir
    //options.Conventions.Add(new LowercaseControllerRouteConvention());
    options.Conventions.Add(new CustomRouteConvention()); // path isimleri burada küçük harfe çevrildi
});

builder.Services.AddDbContext<PortfolioContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"))
    .EnableSensitiveDataLogging();
    #region EnableSensitiveDataLogging
    // Entity Framework Core tarafýndan saðlanan bir seçenektir ve Entity Framework Core'un veritabaný iþlemleri sýrasýnda oluþan sorgularýn ve verilerin hassas bilgilerini (örneðin, veritabaný parolalarý veya hassas kiþisel bilgiler) kaydetmeye veya günlüðe almaya yarar.  Bu seçeneði kullanmak, genellikle geliþtirme ve hata ayýklama aþamasýnda yararlýdýr.Hassas bilgilerin günlüðe alýnmasý, veritabaný iþlemleri sýrasýnda neyin olup bittiðini daha ayrýntýlý bir þekilde anlamak ve hata ayýklamak için kullanýþlýdýr.Ancak, bu özellik prodüksiyon uygulamalarda etkinleþtirilmemelidir, çünkü hassas bilgilerin günlüðe alýnmasý güvenlik sorunlarýna yol açabilir ve veri gizliliðini tehlikeye atabilir. Bu nedenle, EnableSensitiveDataLogging seçeneðini yalnýzca geliþtirme veya hata ayýklama amaçlarý için kullanmalý ve prodüksiyon uygulamalarýnda devre dýþý býrakmalýsýnýz.Bir uygulama prodüksiyon ortamýnda çalýþtýrýldýðýnda, bu seçeneði kullanmamalýsýnýz ve hassas bilgilerin günlüðe alýnmamasýný saðlamalýsýnýz.Bu, uygulama güvenliðini ve kullanýcý verilerinin gizliliðini korumak için önemlidir.
    #endregion

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddHttpClient();
//builder.Services.AddScoped<GithubApiService>(); // GithubApiService'yi ekledik

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Portfolio.Business.Repositories.Concrete.Base.Service>();
builder.Services.AddAutoMapper(typeof(Portfolio.Business.AssemblyRefence).Assembly);


builder.Host.ConfigureAutofac();


builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});



var app = builder.Build();


app.UseStaticFiles();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();