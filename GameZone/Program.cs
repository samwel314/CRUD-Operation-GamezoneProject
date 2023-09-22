using GameZone.Data;
using GameZone.Srvices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.
    AddScoped<ICategoriesService, CategoriesService>();
builder.Services.
    AddScoped<IDevicesService, DevicesService>();
builder.Services.
    AddScoped<IGamesService, GamesService>();

if (builder.Environment.IsDevelopment())
    builder.Configuration.AddUserSecrets<Program>();

var str = builder.Configuration["Constr"]; 

builder.Services.
    AddDbContext<AppDbContext>(x=>x.UseSqlServer(str));

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

app.Run();
