using CommunityToolkit.Mvvm.ComponentModel;
using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services;
using MessageAppFrontend.Services.Interfaces;
using System.Windows;

namespace MessageAppFrontend.ViewModel
{
    public class MainAppViewModel : ObservableObject
    {
        private readonly IViewNavigation _viewNavigation;
        private readonly IUserApiService _userApiService;
        private readonly IChatApiService _chatApiService;
        private readonly IMessageApiService _messageApiService;

        private List<SimpleChat> _chats = new();
        private SimpleChat _selectedChat = null!;
        private User _user = null!;
        private ChatViewModel? _chatViewModel;

        public List<SimpleChat> Chats
        {
            get => _chats;
            set => SetProperty(ref _chats, value);
        }
        public SimpleChat SelectedChat
        {
            get => _selectedChat;
            set
            {
                if(SetProperty(ref _selectedChat, value))
                {
                    LoadChatViewModel();
                }
            }
        }
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        public ChatViewModel? ChatViewModel
        {
            get => _chatViewModel;
            set => SetProperty(ref _chatViewModel, value);
        }

        public MainAppViewModel(IUserApiService userApiService, IViewNavigation viewNavigation, IChatApiService chatApiService, IMessageApiService messageApiService)
        {
            _userApiService = userApiService;
            _viewNavigation = viewNavigation;
            _chatApiService = chatApiService;
            _messageApiService = messageApiService;

            Initialize();
            
        }

        private async void Initialize()
        {
            User = await GetUser();
            Chats = await GetChats();
        }

        private async Task<User> GetUser() 
        {
            User user = null!;
            var response = await _userApiService.GetUser();
            
            if(response.IsSuccess)
            {
                user = response.Data!;
            }
            else
            {
                MessageBox.Show($"Response code: {response.StatusCode}, Error: {response.ErrorMessage}");
                _viewNavigation.NavigateTo<LoginViewModel>();
            }

            return user;
        }

        private async Task<List<SimpleChat>> GetChats()
        {
            List<SimpleChat> chats = new();
            var response = await _userApiService.GetUserChats();
            if (response.IsSuccess)
            {
                chats = response.Data!;
            }
            else
            {
                MessageBox.Show($"Response code: {response.StatusCode}, Error: {response.ErrorMessage}");
                _viewNavigation.NavigateTo<LoginViewModel>();
            }
            return chats;
        }

        private void LoadChatViewModel()
        {
            if(SelectedChat.Id != Guid.Empty)
            {
                ChatViewModel = new ChatViewModel(SelectedChat.Id, User, _chatApiService, _messageApiService);
            }
        }
    }
}
