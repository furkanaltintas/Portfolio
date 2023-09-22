var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();


app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.Run();