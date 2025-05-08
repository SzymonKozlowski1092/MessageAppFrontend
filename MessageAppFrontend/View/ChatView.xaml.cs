using MessageAppFrontend.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MessageAppFrontend.View
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl
    {
        public ChatView()
        {
            InitializeComponent();
            DataContextChanged += ChatView_DataContextChanged;
        }

        private void ChatView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is ChatViewModel vm)
            {
                vm.MessagesLoaded += () =>
                {
                    Dispatcher.InvokeAsync(() => MessagesScrollViewer.ScrollToEnd(), DispatcherPriority.Background);
                };
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ChatMenuPopup.IsOpen = true;
        }

    }
}
