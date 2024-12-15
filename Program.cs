using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration; // For accessing configuration
using personalfinancetracker.Data;
using personalfinancetracker.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5002); // HTTP
    options.ListenLocalhost(5003, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
app.UseSession();

app.Use(async (context, next) =>
{
if(!context.Session.Keys.Contains("UserLoggedIn") && !context.Request.Path.StartsWithSegments("/Account/Login"))
{
    context.Response.Redirect("/Account/Login");
    return;
}
await next();
});

app.MapStaticAssets();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
