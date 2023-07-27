using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using DataBase;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var optionsBuilder = builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>() // Use AddIdentity here
       .AddEntityFrameworkStores<Context>()
       .AddDefaultTokenProviders();

#region Model services
//builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));
#endregion
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(t =>
{
    t.LoginPath = $"/Identity/Account/Login";
    t.LogoutPath = $"/Identity/Account/Logout";
    t.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddDataProtection();
builder.Services.AddAuthentication();


builder.Services.AddMemoryCache();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Main/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseFileServer(new FileServerOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
    RequestPath = new PathString("/node_modules"),
    EnableDirectoryBrowsing = true
});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Main}/{controller=Home}/{action=Index}");

app.Run();
