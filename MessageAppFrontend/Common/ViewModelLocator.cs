using MessageAppFrontend.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MessageAppFrontend.Common
{
    public class ViewModelLocator
    {
        public ChatInvitationsControlViewModel ChatInvitationsControlViewModel =>
        ((App)Application.Current).Services.GetRequiredService<ChatInvitationsControlViewModel>();
    }
}
