using SpacefinderApp.Data;
using SpacefinderApp.Model;
using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpacefinderApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepo;
        private readonly EmailValidator _emailValidator;

        // Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        // Commands
        public ICommand RegisterCommand => new RelayCommand(Register);

        public RegistrationViewModel(UserRepository userRepo, EmailValidator emailValidator)
        {
            _userRepo = userRepo;
            _emailValidator = emailValidator;
        }

        private void Register()
        {
            // 1. Validate email domain
            var (isValid, userType) = _emailValidator.ValidateSchoolEmail(Email);
            if (!isValid) return;

            // 2. Check password match
            if (Password != ConfirmPassword) return;

            // 3. Create user based on role
            User newUser = userType switch
            {
                UserType.Student => new Student { RNumber = ExtractRNumber(Email) },
                UserType.Teacher => new Teacher { UNumber = ExtractUNumber(Email) },
                _ => throw new InvalidOperationException()
            };

            newUser.Email = Email;
            newUser.PasswordHash = PasswordHasher.Hash(Password);
            _userRepo.AddUser(newUser);

            // 4. Send verification email
            EmailService.SendVerificationEmail(newUser);
        }

        private string ExtractRNumber(string email) => email.Split('@')[0].ToUpper();
    }
}
