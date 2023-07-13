using Application;
using Application.Common.Interfaces;
using HomeBookkeeping.Services;
using Infrastructure;
using System.Reflection;

namespace HomeBookkeeping;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthentication();

        builder.Services.AddAuthorization();
        builder.Services.AddApplication();
        builder.Services.AddScoped<ICurrentUserService, CurrentUser>();

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddHttpContextAccessor();
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
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
