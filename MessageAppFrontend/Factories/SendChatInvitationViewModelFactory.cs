using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories
{
    public class SendChatInvitationViewModelFactory : ISendChatInvitationViewModelFactory 
    {
        private readonly IChatInvitationApiService _chatInvitationApiService;
        private readonly IUserApiService _userApiService;

        public SendChatInvitationViewModelFactory(IChatInvitationApiService chatInvitationApiService, IUserApiService userApiService)
        {
            _chatInvitationApiService = chatInvitationApiService;
            _userApiService = userApiService;
        }

        public SendChatInvitationViewModel Create(Guid chatId) => new SendChatInvitationViewModel(_chatInvitationApiService, _userApiService, chatId);
    }
}
