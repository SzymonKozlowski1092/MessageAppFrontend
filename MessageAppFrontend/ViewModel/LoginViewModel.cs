using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Common;

namespace MessageAppFrontend.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IViewNavigation _viewNavigation;

        private string? _username;
        private string? _password;

        public string? Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string? Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel(IViewNavigation viewNavigation)
        {
            _viewNavigation = viewNavigation;
        }

        public ICommand LoginCommand => new RelayCommand(() =>
        {
            if(!(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)))
            {
                MessageBox.Show($"Login with: Username: {Username} and Password: {Password}");
            }
            else
            {
                MessageBox.Show("Nieprawidłowe dane logowania.");
            }
        });

        public ICommand RegisterCommand => new RelayCommand(() =>
        {
            _viewNavigation.NavigateTo<RegisterViewModel>();
        });

        public ICommand ResetPasswordCommand => new RelayCommand(() =>
        {
            MessageBox.Show("Reset Password");
        });
    }
}
