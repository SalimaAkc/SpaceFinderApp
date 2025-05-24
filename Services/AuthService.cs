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
    public class AuthService
    {
        private readonly UserRepository _userRepo;
        private readonly EmailValidator _emailValidator; // Add this if you have email functionality

        public AuthService(UserRepository userRepo)
        {
            _userRepo = userRepo;
            // _emailService = emailService; // Initialize if you implement email
        }

        public (bool Success, User User) Login(string email, string password)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user == null) return (false, null);

            // Verify password against stored hash
            bool isPasswordValid = PasswordHasher.Verify(password, user.PasswordHash); // <--- HERE

            return (isPasswordValid, user);
        }

        public (bool Success, string ErrorMessage) Register(User user, string password)
        {
            // Validate email format
            var (isValidEmail, _) = EmailValidator.ValidateSchoolEmail(user.Email);
            if (!isValidEmail) return (false, "Invalid school email format");

            // Hash the password before storing
            user.PasswordHash = PasswordHasher.Hash(password); // <--- HERE

            try
            {
                _userRepo.CreateUser(user);
                return (true, "Registration successful");
            }
            catch (Exception ex)
            {
                return (false, $"Registration failed: {ex.Message}");
            }
        }

        public bool ResetPassword(string email, string newPassword)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user == null) return false;

            // Hash new password before saving
            user.PasswordHash = PasswordHasher.Hash(newPassword);
            // <--- HERE
            _userRepo.UpdateUser(user);
            return true;
        }
    }
}