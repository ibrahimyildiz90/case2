using MicroServices.Services.Obilet.Application.Services;
using MicroServices.Services.Obilet.Application.Settings;

//using MicroService.UI.Obilet.MVC.Interfaces;
//using MicroService.UI.Obilet.MVC.Services;


var builder = WebApplication.CreateBuilder(args);


AppSettings appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddSingleton(_ => appSettings);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IIntegrationService, IntegrationService>();


builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
