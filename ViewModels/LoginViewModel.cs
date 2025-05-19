using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpacefinderApp.Services;

namespace SpacefinderApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly AuthService _authService;

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
        }

        public bool Login()
        {
            return _authService.Authenticate(Email, Password) != null;
        }

        public void RequestPasswordReset(string email)
        {
            // Implement password reset logic
        }
    }
}
