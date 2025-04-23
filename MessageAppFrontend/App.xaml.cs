using System.Configuration;
using System.Data;
using System.Windows;
using MessageAppFrontend.Common;
using MessageAppFrontend.View;
using MessageAppFrontend.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace MessageAppFrontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var viewNavigation = _serviceProvider.GetRequiredService<IViewNavigation>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            viewNavigation.NavigateTo<LoginViewModel>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<IViewNavigation, ViewNavigation>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<RegisterView>();
            services.AddSingleton<LoginView>();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

}
