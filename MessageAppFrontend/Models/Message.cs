using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MessageAppFrontend.Models
{
    public class Message : ObservableObject
    {
        private Guid _id;
        private Guid _senderId;
        private string _senderDisplayName = null!;
        private string _content = null!;
        private DateTime _sentAt;

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public Guid SenderId
        {
            get => _senderId;
            set => SetProperty(ref _senderId, value);
        }
        public string SenderDisplayName
        {
            get => _senderDisplayName;
            set => SetProperty(ref _senderDisplayName, value);
        }
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
        public DateTime SentAt
        {
            get => _sentAt;
            set => SetProperty(ref _sentAt, value);
        }
    }
}
