using CommunityToolkit.Mvvm.ComponentModel;

namespace MessageAppFrontend.Models
{
    public class SimpleChat : ObservableObject
    {
        private Guid _id;
        private string _name = null!;
        private string _lastMessageContent = null!;
        private string _lastMessageSenderDisplayName = null!;
        private DateTime _lastMessageSentTime = default;

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

        public DateTime LastMessageSentTime
        {
            get => _lastMessageSentTime;
            set => SetProperty(ref _lastMessageSentTime, value);
        }
    }
}
