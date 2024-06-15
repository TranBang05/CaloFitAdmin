using AdminFe.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<HomeController>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<HomeController>>();
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new HomeController(logger, httpClientFactory);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
