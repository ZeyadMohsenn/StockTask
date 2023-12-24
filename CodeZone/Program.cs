using CodeZone.DAL;
using CodeZone.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
#region Database
string? connectionString = builder.Configuration.GetConnectionString("Stock");
builder.Services.AddDbContext<StockContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

#region Repos
builder.Services.AddScoped<IStoreRepo, StoreRepo>();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IStoreItemRepo, StoreItemRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


#endregion
#region Manager
builder.Services.AddScoped<IStoreManager, StoreManager>();
builder.Services.AddScoped<IItemManager, ItemManager>();
builder.Services.AddScoped<IStoreItemManager, StoreItemManager>();

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
