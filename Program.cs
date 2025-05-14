var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable static files (e.g. CSS/JS)
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable MVC endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");
});

app.Run();