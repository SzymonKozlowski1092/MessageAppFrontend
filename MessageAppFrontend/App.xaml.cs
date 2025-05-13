using System.Windows;
using MessageAppFrontend.Common;
using MessageAppFrontend.Factories;
using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Services;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace MessageAppFrontend
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            LoggingConfig.Setup();
            var logger = NLog.LogManager.GetCurrentClassLogger();

            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Application startup failed");
                MessageBox.Show("Błąd krytyczny przy starcie aplikacji");
                throw;
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainAppViewModel>();

            services.AddSingleton<IViewNavigation, ViewNavigation>();

            services.AddTransient<IAccountApiService, AccountApiService>();
            services.AddTransient<IUserApiService, UserApiService>();
            services.AddTransient<IChatApiService, ChatApiService>();
            services.AddTransient<IMessageApiService, MessageApiService>();
            services.AddTransient<IChatInvitationApiService, ChatInvitationApiService>();

            services.AddTransient<IChatViewModelFactory, ChatViewModelFactory>();
            services.AddTransient<INewChatViewModelFactory, NewChatViewModelFactory>();
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
