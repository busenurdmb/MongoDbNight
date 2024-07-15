using Microsoft.Extensions.Options;
using MongoDbNight.Services.CategoryServices;
using MongoDbNight.Services.CustomerServices;
using MongoDbNight.Services.GoogleClouds;
using MongoDbNight.Services.OrderServices;
using MongoDbNight.Services.ProductServices;
using MongoDbNight.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
#region registration
// IService ve Service arasýndaki baðýmlýlýðý Scoped olarak kaydeder.
// Scoped: Her istek (request) için bir örnek oluþturulur.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();

// Geçerli assembly'deki tüm AutoMapper profillerini tarar ve AutoMapper'ý yapýlandýrýr.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//veri tabaný baðlantý adresini appsettings.json dan okuyacak
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// IDatabaseSettings için bir baðýmlýlýðý Scoped olarak kaydeder.
// Gerekli ayarlarý IOptions<DatabaseSettings> üzerinden alýr ve döner.veritabanýadý ,koleksiyon adý, vb
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();

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
