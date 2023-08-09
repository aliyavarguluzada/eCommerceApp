using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(builder.Configuration["Database:Connection"]));

var app = builder.Build();

app.MapControllerRoute("default",
    "{controller=Home}/{action=Index}");

app.UseStaticFiles();

app.Run();
