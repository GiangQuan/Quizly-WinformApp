using System;
using System.Linq;
using Quizly.Data.Models;

namespace Quizly.Data
{
    public static class DbSeeder
    {
        public static void Seed(QuizlyDbContext db)
        {
            // nếu đã có dữ liệu, bỏ qua
            if (db.Users.Any())
                return;

            // 1️⃣ Tạo user admin
            var admin = new User
            {
                Email = "admin@quizly.local",
                PasswordHash = "admin", // ⚠️ chỉ để dev/test, sau nên hash
                DisplayName = "Admin",
                Role = Role.Admin,
                CreatedAt = DateTime.UtcNow
            };
            db.Users.Add(admin);
            db.SaveChanges();

            // 2️⃣ Tạo quiz mẫu
            var quiz = new Quiz
            {
                Title = "Sample Quiz",
                Description = "This is a sample quiz to test the app.",
                CreatedById = admin.Id,
                IsPublished = true,
                TimeLimitSeconds = 0,
                Tags = "sample,math"
            };

            // 3️⃣ Thêm câu hỏi và lựa chọn
            var question = new Question
            {
                Text = "What is 1 + 1?",
                Type = QuestionType.MultipleChoice,
                Order = 1
            };
            question.Choices.Add(new Choice { Text = "1", IsCorrect = false });
            question.Choices.Add(new Choice { Text = "2", IsCorrect = true });
            question.Choices.Add(new Choice { Text = "3", IsCorrect = false });
            quiz.Questions.Add(question);

            db.Quizzes.Add(quiz);
            db.SaveChanges();
        }
    }
}
