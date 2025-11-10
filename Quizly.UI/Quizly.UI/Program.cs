using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using Quizly.Data;
using Quizly.UI;

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
                // services.AddScoped<IAuthService, AuthService>(); // nếu đã tạo
            })
            .UseConsoleLifetime();

        using var host = builder.Build();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var login = host.Services.GetRequiredService<LoginForm>();
        Application.Run(login);
    }
}
