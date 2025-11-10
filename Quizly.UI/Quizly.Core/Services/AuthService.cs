using System.Linq;
using Quizly.Data;
using Quizly.Data.Models;

namespace Quizly.Core.Services
{
    public interface IAuthService
    {
        User? Authenticate(string email, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly QuizlyDbContext _db;
        public AuthService(QuizlyDbContext db) => _db = db;

        public User? Authenticate(string email, string password)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
    }
}
