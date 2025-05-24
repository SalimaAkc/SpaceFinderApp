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
    public class AuthViewModel : INotifyPropertyChanged
    {
        // Properties
        private string _email = string.Empty;
        private string _password = string.Empty;
        private bool _isPasswordVisible;
        private string _errorMessage = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));
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
        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand TogglePasswordVisibilityCommand { get; }
        public bool LoginIsValid { get; private set; }

        public AuthViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            TogglePasswordVisibilityCommand = new RelayCommand(() => IsPasswordVisible = !IsPasswordVisible);
            // Initialize other commands similarly
        }

        private void ExecuteLogin(object? parameter)
        {
            // Your login logic
            if (LoginIsValid)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    new MainWindow().Show();
                    Application.Current.MainWindow?.Close();
                });
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
