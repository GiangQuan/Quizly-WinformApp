namespace Quizly.Data.Models;

public enum Role { User, Creator, Admin }

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public Role Role { get; set; } = Role.User;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Result> Results { get; set; } = new List<Result>();
}
