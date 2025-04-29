using CommunityToolkit.Mvvm.ComponentModel;

namespace MessageAppFrontend.Models
{
    public class Chat : ObservableObject
    {
        private Guid _id;
        private string _name = null!;
        private string _lastMessageContent = null!;
        private string _lastMessageSenderDisplayName = null!;

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string LastMessageContent
        {
            get => _lastMessageContent;
            set => SetProperty(ref _lastMessageContent, value);
        }
        public string LastMessageSenderDisplayName
        {
            get => _lastMessageSenderDisplayName;
            set => SetProperty(ref _lastMessageSenderDisplayName, value);
        }
    }
}
