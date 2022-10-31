using AdminPanel.Business.Infrastructure;
using AdminPanel.Data.Infrastructure;
using AdminPanel.Search.Infrastructure;
using AdminPanel.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("devsettings.json", true);

// Add services to the container.
builder.Services.AddControllersWithViews(o =>
{
    o.Filters.Add<PermissionFilter>();
});

builder.Services.AddData(builder.Configuration);

builder.Services.AddBusiness();

builder.Services.AddSearch();

var app = builder.Build();

app.UsePermissions();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
