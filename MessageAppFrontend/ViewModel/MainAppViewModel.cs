using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Common;
using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MessageAppFrontend.ViewModel
{
    public class MainAppViewModel : ObservableObject
    {
        private readonly IViewNavigation _viewNavigation;
        private readonly IUserApiService _userApiService;
        private readonly IChatViewModelFactory _chatViewModelFactory;
        private readonly INewChatViewModelFactory _newChatViewModelFactory;
        private readonly IChatInvitationApiService _chatInvitationApiService;

        private ObservableCollection<SimpleChat> _chats = new();
        private ObservableCollection<ChatInvitation> _chatInvitations = new();
        private SimpleChat _selectedChat = null!;
        private User _user = null!;
        private ChatViewModel? _chatViewModel;
        private bool _isNotificationsPopupOpen = false;

        public ObservableCollection<SimpleChat> Chats
        {
            get => _chats;
            set => SetProperty(ref _chats, value);
        }
        public ObservableCollection<ChatInvitation> ChatInvitations 
        { 
            get => _chatInvitations; 
            set => SetProperty(ref _chatInvitations, value); 
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
        public bool IsNotificationsPopupOpen
        {
            get => _isNotificationsPopupOpen;
            set => SetProperty(ref _isNotificationsPopupOpen, value);
        }

        public MainAppViewModel(IUserApiService userApiService, IViewNavigation viewNavigation, IChatApiService chatApiService, IChatViewModelFactory chatViewModelFactory, INewChatViewModelFactory createNewChatViewModelFactory, IChatInvitationApiService chatInvitationApiService)
        {
            _userApiService = userApiService;
            _viewNavigation = viewNavigation;
            _chatViewModelFactory = chatViewModelFactory;
            _newChatViewModelFactory = createNewChatViewModelFactory;
            _chatInvitationApiService = chatInvitationApiService;

            Initialize();
        }

        private async void Initialize()
        {
            User = await GetUser();
            Chats = await GetChats();
            ChatInvitations = await GetChatInvitations();
        }

        public ICommand AddChatCommand => new AsyncRelayCommand(async () =>
        {
            NewChatWindow newChatWindow = new NewChatWindow();
            newChatWindow.DataContext = _newChatViewModelFactory.CreateNewChatViewModel(User.Id);

            newChatWindow.ShowDialog();

            Chats = await GetChats();
        });

        public ICommand ShowNotificationsCommand => new AsyncRelayCommand(async () => 
        {
            IsNotificationsPopupOpen = !IsNotificationsPopupOpen;
            if (!IsNotificationsPopupOpen)
            {
                await GetChats();
            }
        });

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

        private async Task<ObservableCollection<SimpleChat>> GetChats()
        {
            List<SimpleChat> chats = new();
            var response = await _userApiService.GetUserChats();
            if (response.IsSuccess)
            {
                chats = response.Data!;
                chats = chats.OrderByDescending(c => c.LastMessageSentTime).ToList();
            }
            else
            {
                MessageBox.Show($"Response code: {response.StatusCode}, Error: {response.ErrorMessage}");
                _viewNavigation.NavigateTo<LoginViewModel>();
            }
            
            return new ObservableCollection<SimpleChat>(chats);
        }

        private async Task<ObservableCollection<ChatInvitation>> GetChatInvitations()
        {
            var apiResponse = await _chatInvitationApiService.GetActiveChatInvitations();
            if (!apiResponse.IsSuccess)
            {
                if (apiResponse.StatusCode == 404)
                {
                    return new();
                }

                MessageBox.Show($"Wystąpił błąd podczas ładowania zaproszeń: {apiResponse.ErrorMessage}", "Błąd");
                return new();
            }

            return new ObservableCollection<ChatInvitation>(apiResponse.Data!);
        }

        private void LoadChatViewModel()
        {
            if(SelectedChat.Id != Guid.Empty)
            {
                ChatViewModel = _chatViewModelFactory.Create(SelectedChat.Id, User);
            }
        }
    }
}
