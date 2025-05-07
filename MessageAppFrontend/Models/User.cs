using CommunityToolkit.Mvvm.ComponentModel;

namespace MessageAppFrontend.Models
{
    public class User : ObservableObject
    {
        private Guid _id;
        private string _username = null!;
        private string _displayName = null!;
        private string _email = null!;

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
    }
}
