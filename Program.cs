using MovieEventBooking.Services;
using MovieEventBooking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// MongoDB Config
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoService>();

var app = builder.Build();

// Middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.Run();
