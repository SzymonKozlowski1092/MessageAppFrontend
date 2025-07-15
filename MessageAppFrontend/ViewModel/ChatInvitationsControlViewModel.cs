using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace MessageAppFrontend.ViewModel
{
    public class ChatInvitationsControlViewModel : ObservableObject
    {
        private readonly IChatInvitationApiService _chatInvitationApiService;

        private ChatInvitation invitation = null!;

        public ChatInvitation Invitation 
        { 
            get => invitation; 
            set => SetProperty(ref invitation, value); 
        }

        public ChatInvitationsControlViewModel(IChatInvitationApiService chatInvitationApiService)
        {
            _chatInvitationApiService = chatInvitationApiService;
        }

        public ICommand AcceptInvitationCommand => new AsyncRelayCommand(async() =>
        {
            var apiResponse = await _chatInvitationApiService.AcceptChatInvitation(Invitation.Id);
            if (!apiResponse.IsSuccess) 
            {
                MessageBox.Show(apiResponse.ErrorMessage, apiResponse.StatusCode.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Pomyślnie dołączono do czatu {Invitation.ChatName}", apiResponse.StatusCode.ToString(), MessageBoxButton.OK);
        });

        public ICommand DeclineInvitationCommand => new AsyncRelayCommand(async () =>
        {
            var apiResponse = await _chatInvitationApiService.AcceptChatInvitation(Invitation.Id);
            if (!apiResponse.IsSuccess)
            {
                MessageBox.Show(apiResponse.ErrorMessage, apiResponse.StatusCode.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Pomyślnie dołączono do czatu {Invitation.ChatName}", apiResponse.StatusCode.ToString(), MessageBoxButton.OK);
        });
    }
}
