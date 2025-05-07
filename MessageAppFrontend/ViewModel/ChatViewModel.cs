using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MessageAppFrontend.ViewModel
{
    public class ChatViewModel : ObservableObject
    {
        private readonly IChatApiService _chatApiService;
        private readonly IMessageApiService _messageApiService;

        private User user = null!;
        private Chat _chat = null!;
        private ObservableCollection<Message> _messages = new();
        private ObservableCollection<User> _users = new();
        private string _name = string.Empty;
        private string _messageContent = string.Empty;

        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public Chat Chat
        {
            get => _chat;
            set => SetProperty(ref _chat, value);
        }
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }
        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string MessageContent
        {
            get => _messageContent;
            set => SetProperty(ref _messageContent, value);
        }

        public ChatViewModel(Guid chatId, User user, IChatApiService chatApiService, IMessageApiService messageApiService)
        {
            _chatApiService = chatApiService;
            _messageApiService = messageApiService;
            User = user;
            Initialize(chatId);
            
        }

        public ICommand SendMessageCommand => new AsyncRelayCommand(async () =>
        {
            NewMessage newMessage = new NewMessage()
            {
                Content = MessageContent,
                ChatId = Chat.Id
            };
            
            var response = await _messageApiService.SendMessage(newMessage);
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Response code: {response.StatusCode}, Error: {response.ErrorMessage}\nNie udało się wysłać wiadomości");
            }
            
            Messages.Add(new Message()
            {
                Content = MessageContent,
                SenderId = User.Id,
                SenderDisplayName = User.DisplayName,
            });

            MessageContent = string.Empty;
        });

        public async void Initialize(Guid chatId)
        {
            Chat = await GetChat(chatId);
            if (Chat != null)
            {
                Name = Chat.Name;
                Users = new ObservableCollection<User>(Chat.Users);
                Messages = new ObservableCollection<Message>(Chat.Messages);
            }
        }

        private async Task<Chat> GetChat(Guid chatId)
        {
            var response = await _chatApiService.GetChat(chatId);
            if (response.IsSuccess)
            {
                return response.Data!;
            }
            else
            {
                MessageBox.Show($"Response code: {response.StatusCode}, Error: {response.ErrorMessage}\nNie udało się załadować czatu");
                return null!;
            }
        }
    }
}
