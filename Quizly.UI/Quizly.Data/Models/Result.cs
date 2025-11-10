using Quizly.Data.Models;

public class Result
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public decimal Score { get; set; }
    public decimal MaxScore { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime TakenAt { get; set; } = DateTime.UtcNow;
    public ICollection<AttemptDetail> Details { get; set; } = new List<AttemptDetail>();
}