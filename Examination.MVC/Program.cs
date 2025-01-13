using Examination.BL.Services.Abstractions;
using Examination.BL.Services.Implementations;
using Examination.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Hp")));
builder.Services.AddScoped<ICartItemService, CartItemService>();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=home}/{action=index}/{id?}");


app.Run();
