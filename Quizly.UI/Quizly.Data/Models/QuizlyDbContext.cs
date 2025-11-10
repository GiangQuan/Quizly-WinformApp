using Microsoft.EntityFrameworkCore;
using Quizly.Data.Models;

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
    }
}
