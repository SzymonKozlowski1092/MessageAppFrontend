using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories
{
    public class ChatInvitationsControlViewModelFactory : IChatInvitationsControlViewModelFactory
    {
        private readonly IChatInvitationApiService _chatInvitationApiService;
        public ChatInvitationsControlViewModelFactory(IChatInvitationApiService chatInvitationApiService)
        {
            _chatInvitationApiService = chatInvitationApiService;
        }

        public ChatInvitationsControlViewModel Create() => new ChatInvitationsControlViewModel(_chatInvitationApiService);
    }
}
