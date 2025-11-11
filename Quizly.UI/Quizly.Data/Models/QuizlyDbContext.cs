using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;
using System;
using System.Security.Cryptography;
using System.Text;

public class QuizlyDbContext : DbContext
{
    public QuizlyDbContext(DbContextOptions<QuizlyDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<AttemptDetail> AttemptDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        // Configure Quiz -> Questions relationship
        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Question -> Choices relationship
        modelBuilder.Entity<Question>()
            .HasMany(q => q.Choices)
            .WithOne(c => c.Question)
            .HasForeignKey(c => c.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure cascade delete behavior to avoid cycles
        modelBuilder.Entity<Result>()
            .HasOne(r => r.User)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Result>()
            .HasOne(r => r.Quiz)
            .WithMany()
            .HasForeignKey(r => r.QuizId)
            .OnDelete(DeleteBehavior.NoAction);

        // Configure AttemptDetail relationships
        modelBuilder.Entity<AttemptDetail>()
            .HasOne(ad => ad.Result)
            .WithMany(r => r.Details)
            .HasForeignKey(ad => ad.ResultId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AttemptDetail>()
            .HasOne(ad => ad.Question)
            .WithMany()
            .HasForeignKey(ad => ad.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AttemptDetail>()
            .HasOne(ad => ad.SelectedChoice)
            .WithMany()
            .HasForeignKey(ad => ad.SelectedChoiceId)
            .OnDelete(DeleteBehavior.NoAction);

        // ✅ SEED DATA
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Helper method to hash password
        string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "admin@quizly.com",
                PasswordHash = HashPassword("Admin@123"),
                DisplayName = "Administrator",
                Role = Role.Admin,
                CreatedAt = new DateTime(2024, 1, 1)
            },
            new User
            {
                Id = 2,
                Email = "user@quizly.com",
                PasswordHash = HashPassword("User@123"),
                DisplayName = "Test User",
                Role = Role.User,
                CreatedAt = new DateTime(2024, 1, 1)
            }
        );

        // Seed Quiz
        modelBuilder.Entity<Quiz>().HasData(
            new Quiz
            {
                Id = 1,
                Title = "Math Quiz - Basic",
                Description = "Test your basic math skills",
                TimeLimitSeconds = 600, // 10 minutes
                IsPublished = true,
                Tags = "math, basic, arithmetic",
                CreatedById = 1
            },
            new Quiz
            {
                Id = 2,
                Title = "General Knowledge",
                Description = "Test your general knowledge",
                TimeLimitSeconds = 0, // No limit
                IsPublished = true,
                Tags = "general, knowledge",
                CreatedById = 1
            }
        );

        // Seed Questions for Quiz 1
        modelBuilder.Entity<Question>().HasData(
            new Question { Id = 1, QuizId = 1, Text = "What is 2 + 2?", Type = QuestionType.MultipleChoice, Order = 1 },
            new Question { Id = 2, QuizId = 1, Text = "What is 10 - 5?", Type = QuestionType.MultipleChoice, Order = 2 },
            new Question { Id = 3, QuizId = 1, Text = "What is 3 × 4?", Type = QuestionType.MultipleChoice, Order = 3 }
        );

        // Seed Questions for Quiz 2
        modelBuilder.Entity<Question>().HasData(
            new Question { Id = 4, QuizId = 2, Text = "What is the capital of France?", Type = QuestionType.MultipleChoice, Order = 1 },
            new Question { Id = 5, QuizId = 2, Text = "How many continents are there?", Type = QuestionType.MultipleChoice, Order = 2 }
        );

        // Seed Choices for Question 1: "What is 2 + 2?"
        modelBuilder.Entity<Choice>().HasData(
            new Choice { Id = 1, QuestionId = 1, Text = "3", IsCorrect = false },
            new Choice { Id = 2, QuestionId = 1, Text = "4", IsCorrect = true },
            new Choice { Id = 3, QuestionId = 1, Text = "5", IsCorrect = false },
            new Choice { Id = 4, QuestionId = 1, Text = "6", IsCorrect = false }
        );

        // Seed Choices for Question 2: "What is 10 - 5?"
        modelBuilder.Entity<Choice>().HasData(
            new Choice { Id = 5, QuestionId = 2, Text = "3", IsCorrect = false },
            new Choice { Id = 6, QuestionId = 2, Text = "4", IsCorrect = false },
            new Choice { Id = 7, QuestionId = 2, Text = "5", IsCorrect = true },
            new Choice { Id = 8, QuestionId = 2, Text = "6", IsCorrect = false }
        );

        // Seed Choices for Question 3: "What is 3 × 4?"
        modelBuilder.Entity<Choice>().HasData(
            new Choice { Id = 9, QuestionId = 3, Text = "10", IsCorrect = false },
            new Choice { Id = 10, QuestionId = 3, Text = "11", IsCorrect = false },
            new Choice { Id = 11, QuestionId = 3, Text = "12", IsCorrect = true },
            new Choice { Id = 12, QuestionId = 3, Text = "13", IsCorrect = false }
        );

        // Seed Choices for Question 4: "Capital of France"
        modelBuilder.Entity<Choice>().HasData(
            new Choice { Id = 13, QuestionId = 4, Text = "London", IsCorrect = false },
            new Choice { Id = 14, QuestionId = 4, Text = "Paris", IsCorrect = true },
            new Choice { Id = 15, QuestionId = 4, Text = "Berlin", IsCorrect = false },
            new Choice { Id = 16, QuestionId = 4, Text = "Madrid", IsCorrect = false }
        );

        // Seed Choices for Question 5: "Continents"
        modelBuilder.Entity<Choice>().HasData(
            new Choice { Id = 17, QuestionId = 5, Text = "5", IsCorrect = false },
            new Choice { Id = 18, QuestionId = 5, Text = "6", IsCorrect = false },
            new Choice { Id = 19, QuestionId = 5, Text = "7", IsCorrect = true },
            new Choice { Id = 20, QuestionId = 5, Text = "8", IsCorrect = false }
        );
    }
}