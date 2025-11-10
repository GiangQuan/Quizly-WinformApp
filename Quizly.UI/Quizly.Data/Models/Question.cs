public enum QuestionType { MultipleChoice, TrueFalse, FillIn }

public class Question
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public string Text { get; set; } = "";
    public QuestionType Type { get; set; } = QuestionType.MultipleChoice;
    public ICollection<Choice> Choices { get; set; } = new List<Choice>();
    public int Order { get; set; } = 0;
}
