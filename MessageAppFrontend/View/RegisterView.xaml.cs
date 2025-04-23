using System.Windows.Controls;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.View
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            this.DataContext = new RegisterViewModel();
        }
    }
}
