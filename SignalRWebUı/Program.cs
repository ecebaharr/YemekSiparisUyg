using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Giriş zorunluluğu
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Services
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

// Cookie ayarları
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Hata sayfası
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFound404Page/");
    }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
