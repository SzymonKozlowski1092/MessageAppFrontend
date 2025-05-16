using MessageAppFrontend.Models;
using MessageAppFrontend.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppFrontend.View.Controls
{
    /// <summary>
    /// Interaction logic for ChatInvitationControl.xaml
    /// </summary>
    public partial class ChatInvitationControl : UserControl
    {
        private ChatInvitationsControlViewModel? _viewModel;

        public ChatInvitationControl()
        {
            InitializeComponent();
        }

        public ChatInvitation Invitation
        {
            get => (ChatInvitation)GetValue(InvitationProperty);
            set => SetValue(InvitationProperty, value);
        }

        public static readonly DependencyProperty InvitationProperty =
            DependencyProperty.Register(
                nameof(Invitation),
                typeof(ChatInvitation),
                typeof(ChatInvitationControl),
                new PropertyMetadata(null, OnInvitationChanged));

        private static void OnInvitationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ChatInvitationControl control && e.NewValue is ChatInvitation invitation)
            {
                var vm = ((App)Application.Current).Services.GetRequiredService<ChatInvitationsControlViewModel>();
                vm.Invitation = invitation;

                control.DataContext = vm;

                control._viewModel = vm;
            }
        }
    }
}
