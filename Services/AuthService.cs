using SpacefinderApp.Data;
using SpacefinderApp.Model;
using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Services
{
    public class AuthService(UserRepository userRepo)
    {
        private readonly UserRepository _userRepo = userRepo;

        public (bool Success, User User) Login(string email, string password)
        {
            // Validate email format first
            var (isValidEmail, userType) = EmailValidator.ValidateSchoolEmail(email);
            if (!isValidEmail) return (false, null);

            // Get user from database
            var user = _userRepo.GetUserByEmail(email);
            if (user == null) return (false, null);

            // Verify password and role consistency
            bool isPasswordValid = PasswordHasher.Verify(password, user.PasswordHash);
            bool isRoleConsistent = (userType == user.Type);

            return (isPasswordValid && isRoleConsistent, user);
        }
    }
}
