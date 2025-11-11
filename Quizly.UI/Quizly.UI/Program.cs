using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using Quizly.Data.Models;
using Quizly.UI;
using Quizly.Core.Services;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var conn = context.Configuration.GetConnectionString("QuizlyDb");
                services.AddDbContext<QuizlyDbContext>(options =>
                    options.UseSqlServer(conn));

                // register forms and services
                services.AddTransient<LoginForm>();
                services.AddTransient<MainForm>();
                services.AddTransient<QuizzForm>();
                services.AddScoped<IAuthService, AuthService>();
            })
            .UseConsoleLifetime();

        using var host = builder.Build();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<QuizlyDbContext>();
            db.Database.Migrate();  // tự apply migration
        }

        var login = host.Services.GetRequiredService<LoginForm>();
        Application.Run(login);
    }
}