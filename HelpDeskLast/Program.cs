using HelpDeskIdentity.Models.HelpDeskModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DeskDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("HelpDeskConnection")
));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DeskDbContext>();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(999999999);//You can set Time   
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shared}/{action=login}/{id?}");

app.Run();
