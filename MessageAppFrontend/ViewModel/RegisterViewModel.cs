using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services;

namespace MessageAppFrontend.ViewModel
{
    public class RegisterViewModel : ObservableObject
    {
        private readonly IViewNavigation _viewNavigation;
        private readonly IAccountApiService _accountService;

        public string? _username;
        public string? _displayName;
        public string? _email;
        public string? _password;
        public string? _confirmPassword;

        #region PROPERTIES
        public string Username 
        { 
            get => _username is null ? string.Empty : _username;
            set => SetProperty(ref _username, value);
        }
        public string DisplayName 
        {
            get => _displayName is null ? string.Empty : _displayName;
            set => SetProperty(ref _displayName, value);
        }
        public string Email 
        { 
            get => _email is null ? string.Empty : _email;
            set => SetProperty(ref _email, value);
        }
        public string Password 
        { 
            get => _password is null ? string.Empty : _password;
            set => SetProperty(ref _password, value);
        }
        public string ConfirmPassword 
        { 
            get => _confirmPassword is null ? string.Empty : _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        #endregion

        public RegisterViewModel(IViewNavigation viewNavigation, IAccountApiService accountService)
        {
            _viewNavigation = viewNavigation;
            _accountService = accountService;
        }

        public ICommand GoToLoginViewCommand => new RelayCommand(() =>
        {
            ClearTextBoxes();
            _viewNavigation.NavigateTo<LoginViewModel>();
        });

        public ICommand RegisterCommand => new AsyncRelayCommand(async () =>
        {
            UserRegister userRegister = new UserRegister
            {
                Username = Username,
                DisplayName = DisplayName,
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };

            bool registerResult = await _accountService.RegisterAsync(userRegister);
            if(registerResult)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearTextBoxes();
                _viewNavigation.NavigateTo<LoginViewModel>();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });

        private void ClearTextBoxes()
        {
            Username = string.Empty;
            DisplayName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
