using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using testASP.Service;
using testASP.Domain.Repositories;
using testASP.Domain.Repositories.Abstract;
using testASP.Domain.Repositories.EntityFramework;
using testASP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("Project", new Config());

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldRepository>();
builder.Services.AddTransient<IOptionsRepository, EFOptionsRepository>();
builder.Services.AddTransient<ICategoriesRepository, EFCategoriesRepository>();
builder.Services.AddTransient<IGoodsItemsRepository, EFGoodsItemsRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(ops =>
{
    ops.User.RequireUniqueEmail = true;
    ops.Password.RequiredLength = 6;
    ops.Password.RequireNonAlphanumeric = false;
    ops.Password.RequireLowercase = false;
    ops.Password.RequireUppercase = false;
    ops.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AuthCookie";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "admin",
        "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
         "default",
         "{controller=Home}/{action=Index}/{id?}");
});

app.Run();