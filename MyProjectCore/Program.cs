using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyProjectCore.Filters;
using MyProjectCore.Models;
using MyProjectCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    config.CacheProfiles.Add("Public30Sec", new Microsoft.AspNetCore.Mvc.CacheProfile
    {
        Duration = 30,
        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any,
        VaryByHeader = "user-agent"
    });
    config.CacheProfiles.Add("Private30Sec", new Microsoft.AspNetCore.Mvc.CacheProfile
    {
        Duration = 30,
        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client
    });

    //Register Custom Filter
    //config.Filters.Add(new MyCustomFiltersAttribute("Global", 0));

    //config.Filters.Add(new NewCustomFilter("Global"));
});

//Configure DI
builder.Services.AddScoped<IRepository, AccountRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Accounts/Login";
});

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddResponseCaching();

//Register the MyAsyncActionFilter to Service
//builder.Services.AddScoped<MyAsyncActionFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}");

app.UseResponseCaching();

app.Run();
