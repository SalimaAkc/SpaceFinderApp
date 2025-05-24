using SpacefinderApp.Model;
using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpacefinderApp.ViewModels
{
    public class SettingsViewModel
    {
        public ICommand ChangePasswordCommand => new RelayCommand(ChangePassword);
        public ICommand ForgotPasswordCommand => new RelayCommand(SendPasswordResetLink);

        private void ChangePassword()
        {
            // Validate old password, hash new password, update DB
        }

        private void SendPasswordResetLink()
        {
            var token = GenerateSecureToken();
            EmailValidator.SendPasswordResetLink(user.Email, token);
        }
    }
}
