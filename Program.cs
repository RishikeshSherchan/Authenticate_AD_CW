using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Authentication_V2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Authentication_V2ContextConnection") ?? throw new InvalidOperationException("Connection string 'Authentication_V2ContextConnection' not found.");

builder.Services.AddDbContextPool<Authentication_V2Context>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Authentication_V2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication().AddFacebook(opt =>
    {
        opt.AppId = "";
        opt.AppSecret = "";
    }
);

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

app.MapRazorPages();

app.Run();