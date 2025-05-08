using System.Windows;

namespace MessageAppFrontend.View
{
    /// <summary>
    /// Interaction logic for CreateNewChatWindow.xaml
    /// </summary>
    public partial class NewChatWindow : Window
    {
        public NewChatWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
