using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Quizly.Data
{
    // EF Core tools will discover this class at design time
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<QuizlyDbContext>
    {
        public QuizlyDbContext CreateDbContext(string[] args)
        {
            // Cố gắng load appsettings.json từ project Quizly.UI (startup project)
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Quizly.UI")) 
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var conn = configuration.GetConnectionString("QuizlyDb");

            // Fallback: nếu không tìm thấy, thử biến môi trường
            if (string.IsNullOrWhiteSpace(conn))
            {
                conn = Environment.GetEnvironmentVariable("Quizly__ConnectionString")
                       ?? Environment.GetEnvironmentVariable("ConnectionStrings__QuizlyDb");
            }

            if (string.IsNullOrWhiteSpace(conn))
            {
                throw new InvalidOperationException(
                    "Connection string 'QuizlyDb' not found. " +
                    "Set it in Quizly.UI/appsettings.json or as environment variable 'ConnectionStrings__QuizlyDb'.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<QuizlyDbContext>();
            optionsBuilder.UseSqlServer(conn);

            return new QuizlyDbContext(optionsBuilder.Options);
        }
    }
}
