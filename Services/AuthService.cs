using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacefinderApp.Services;
using SpacefinderApp.Core;
using SpacefinderApp.Data.Models;

namespace SpacefinderApp.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.SchoolEmail == email);

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }
        public bool Register(User user, string password)
        {
            if (_context.Users.Any(u => u.SchoolEmail == user.SchoolEmail))
                return false;

            if (!IsSchoolEmail(user.SchoolEmail))
                return false;

            user.PasswordHash = HashPassword(password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        private bool IsSchoolEmail(string email)
        {
            // Implement your school email validation logic
            return email.EndsWith("@yourschool.edu");
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

    }
}
