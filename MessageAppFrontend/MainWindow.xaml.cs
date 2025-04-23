using System.Windows;
using MessageAppFrontend.View;

namespace MessageAppFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new RegisterView();
        }
    }
}