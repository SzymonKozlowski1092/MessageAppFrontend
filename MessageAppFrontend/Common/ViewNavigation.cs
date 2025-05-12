using System.Windows.Controls;
using MessageAppFrontend.View;
using MessageAppFrontend.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace MessageAppFrontend.Common
{
    public class ViewNavigation : IViewNavigation
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IServiceProvider _serviceProvider;

        public ViewNavigation(MainWindowViewModel mainWindowViewModel, IServiceProvider serviceProvider)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            var viewModel = _serviceProvider.GetRequiredService<TViewModel>();

            UserControl view = typeof(TViewModel).Name switch
            {
                nameof(LoginViewModel) => new LoginView { DataContext = _serviceProvider.GetRequiredService<TViewModel>() },
                nameof(RegisterViewModel) => new RegisterView { DataContext = _serviceProvider.GetRequiredService<TViewModel>() },
                nameof(MainAppViewModel) => new MainAppView { DataContext = _serviceProvider.GetRequiredService<TViewModel>() },
                _ => throw new InvalidOperationException("No view found.")
            };

            _mainWindowViewModel.CurrentView = view;
        }
    }
}