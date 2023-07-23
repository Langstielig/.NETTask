using BusinessLayer;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager configuration = builder.Configuration;

        builder.Services.AddDbContext<EFDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddTransient<ICompanyRepository, EFCompaniesRepository>();
        builder.Services.AddTransient<IProgectsRepository, EFProjectsRepository>();
        builder.Services.AddTransient<IUserRepository, EFUsersRepository>();

        builder.Services.AddScoped<DataManager>();
        builder.Services.AddMvc();

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

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<EFDBContext>();
            SampleData.InitData(context);
        }

        app.Run();
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        })
        .UseNLog();
}