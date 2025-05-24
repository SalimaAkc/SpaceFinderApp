using SpacefinderApp.Services;
using SpacefinderApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpacefinderApp.ViewModels
{
    public class AuthViewModel(AuthService authService) : INotifyPropertyChanged
    {
        private readonly AuthService _authService = authService;
        private string _email = string.Empty;
        private string _errorMessage = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasError));
            }
        }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        // Commands
        public ICommand LoginCommand => new RelayCommand(Login);

        private void Login()
        {
            throw new NotImplementedException();
        }

        public ICommand ForgotPasswordCommand => new RelayCommand(SendPasswordReset);

        private void Login(object parameter)
        {
            if (parameter is not PasswordBox passwordBox)
            {
                ErrorMessage = "Password field error";
                return;
            }

            var password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(Email)
                || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage = "Email and password are required";
                return;


            }

            var (success, user) = _authService.Login(Email, password);
            if (success)
            {
                ErrorMessage = "";
                // Navigate to dashboard (you'll need to implement this)
                MessageBox.Show("Login successful!");
            }
            else
            {
                ErrorMessage = "Invalid credentials";
            }
        }
        private void SendPasswordReset(object? _)
        {
            // Implement password reset logic
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 }
