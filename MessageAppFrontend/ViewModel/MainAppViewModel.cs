using CommunityToolkit.Mvvm.ComponentModel;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.ViewModel
{
    public class MainAppViewModel : ObservableObject
    {
        private List<Chat> _chats = new();
        private User _user = null!;

        public List<Chat> Chats
        {
            get => _chats;
            set => SetProperty(ref _chats, value);
        }
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public MainAppViewModel() 
        {

        }


    }
}
