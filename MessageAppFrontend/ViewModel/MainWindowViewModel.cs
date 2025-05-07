using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MessageAppFrontend.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public UserControl _currentView = null!;
        public UserControl CurrentView 
        { 
            get => _currentView; 
            set => SetProperty(ref _currentView, value); 
        }
    }
}
