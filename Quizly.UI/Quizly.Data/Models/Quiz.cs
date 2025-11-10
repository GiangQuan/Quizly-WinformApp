using Quizly.Data.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int TimeLimitSeconds { get; set; } = 0; // 0 = no limit
    public bool IsPublished { get; set; } = false;
    public string Tags { get; set; } = ""; // comma separated
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
