using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MessageAppFrontend.Common;
using MessageAppFrontend.View;

namespace MessageAppFrontend.ViewModel
{
    public class MainWindowViewModel :ObservableObject
    {
        public UserControl _currentView = null!;
        public UserControl CurrentView 
        { 
            get => _currentView; 
            set => SetProperty(ref _currentView, value); 
        }
    }
}
