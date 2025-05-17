using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace MessageAppFrontend.ViewModel
{
    public class SendChatInvitationViewModel : ObservableObject
    {
        private readonly IChatInvitationApiService _chatInvitationApiService;
        private readonly IUserApiService _userApiService;
        private readonly Guid _chatId = Guid.Empty;

        private string _invitedUsername = string.Empty;
        

        public string InvitedUsername
        {
            get => _invitedUsername;
            set => SetProperty(ref _invitedUsername, value);
        }

        public SendChatInvitationViewModel(IChatInvitationApiService chatInvitationApiService, IUserApiService userApiService, Guid chatId)
        {
            _chatInvitationApiService = chatInvitationApiService;
            _userApiService = userApiService;
            _chatId = chatId;
        }

        public ICommand SendInvitationCommand => new AsyncRelayCommand(async () =>
        {
            var getUserResponse = await _userApiService.GetUserByUsername(_invitedUsername);
            if (!getUserResponse.IsSuccess)
            {
                if(getUserResponse.StatusCode == 404)
                {
                    MessageBox.Show($"Nie znaleziono użytkownika: {_invitedUsername}", "Nie odnaleziono zasobu", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(getUserResponse.StatusCode + " | " + getUserResponse.ErrorMessage, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }
            
            var invitedUser = getUserResponse.Data;
            var newInvitation = new NewChatInvitation(_chatId, invitedUser!.Id);

            var sendInvitationResponse = await _chatInvitationApiService.SendChatInvitation(newInvitation);
            if (!sendInvitationResponse.IsSuccess)
            {
                MessageBox.Show(sendInvitationResponse.StatusCode + " | " + sendInvitationResponse.ErrorMessage, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Pomyślnie zaproszono użytkownika {_invitedUsername}", "Sukces", MessageBoxButton.OK);
        });
    }
}
