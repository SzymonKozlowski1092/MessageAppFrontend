using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services;

namespace MessageAppFrontend.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IViewNavigation _viewNavigation;
        private readonly IAccountService _accountService;

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

        public LoginViewModel(IViewNavigation viewNavigation, IAccountService accountService)
        {
            _viewNavigation = viewNavigation;
            _accountService = accountService;
        }

        public ICommand LoginCommand => new AsyncRelayCommand(async () =>
        {
            //UserLogin userLogin = new UserLogin(Username!, Password!);
            //bool loginResult = await _accountService.LoginAsync(userLogin);
            if(/*loginResult*/true)
            {
                _viewNavigation.NavigateTo<MainAppViewModel>();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.");
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
