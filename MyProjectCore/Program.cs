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
});

builder.Services.AddResponseCaching();

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

app.UseResponseCaching();

app.Run();
