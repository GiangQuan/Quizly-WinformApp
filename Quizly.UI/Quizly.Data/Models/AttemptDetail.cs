public class AttemptDetail
{
    public int Id { get; set; }
    public int ResultId { get; set; }
    public Result Result { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int? SelectedChoiceId { get; set; }
    public Choice SelectedChoice { get; set; }
    public bool IsCorrect { get; set; }
}