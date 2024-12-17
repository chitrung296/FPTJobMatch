using FPTJobMatch.MVC.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MVCJobMatchConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'MVCJobMatchConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DataService>();

var app = builder.Build();

var isDevelopEnvironment = app.Environment.IsDevelopment();
var isProductionEnvironment = app.Environment.IsProduction();

// Configure the HTTP request pipeline.
if (!isDevelopEnvironment)
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


if (isDevelopEnvironment)
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
else
{
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Job}/{action=Create}/{id?}");
}


app.Run();
