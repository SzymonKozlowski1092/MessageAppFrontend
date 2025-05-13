using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace MessageAppFrontend.ViewModel
{
    public class NewChatViewModel : ObservableObject
    {
        private readonly IChatApiService _chatApiService;

        private Guid _userId = Guid.Empty;
        private string _chatName = string.Empty;

        public string ChatName
        {
            get => _chatName;
            set
            {
                _chatName = value;
                OnPropertyChanged(nameof(ChatName));
            }
        }

        public NewChatViewModel(Guid userId, IChatApiService chatApiService)
        {
            _userId = userId;
            _chatApiService = chatApiService;
        }

        public ICommand CreateNewChatCommand => new AsyncRelayCommand(async () =>
        {
            NewChat newChat = new NewChat
            {
                Name = ChatName,
                UserId = _userId
            };
            var response = await _chatApiService.CreateChat(newChat);
            if(!response.IsSuccess)
            {
                MessageBox.Show($"Code: {response.StatusCode}, Error: {response.ErrorMessage}.\nNie udało się utworzyć czatu");
                return;
            }

            MessageBox.Show($"Czat: {newChat.Name} został utworzony");
            ChatName = string.Empty;
        });
    }
}
