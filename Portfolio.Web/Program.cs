using Portfolio.Business.DependencyResolvers.Microsoft;
using Portfolio.Core.DependencyResolvers;
using Portfolio.Core.Extensions;
using Portfolio.Core.Utilities.IoC;
using Portfolio.Web.Extensions;
using Portfolio.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// UI
builder.Services.StartupExtensions(builder.Configuration, builder.Host);

// Business
builder.Services.ServiceExtensions();


builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

bool maintenanceMode = builder.Configuration.GetValue<bool>("MaintenanceMode");
app.UseMiddleware<MaintenanceModeMiddleware>(maintenanceMode); // Bakým modunu etkinleþtirir veya devre dýþý býrakýr.

#region Route
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
#endregion

app.Run();