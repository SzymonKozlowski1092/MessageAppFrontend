using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories
{
    public class ChatViewModelFactory : IChatViewModelFactory
    {
        private readonly IChatApiService _chatApiService;
        private readonly IMessageApiService _messageApiService;
        private readonly ISendChatInvitationViewModelFactory _sendChatInvitationViewModelFactory;
        public ChatViewModelFactory(IChatApiService chatApiService, IMessageApiService messageApiService, ISendChatInvitationViewModelFactory sendChatInvitationViewModelFactory)
        {
            _chatApiService = chatApiService;
            _messageApiService = messageApiService;
            _sendChatInvitationViewModelFactory = sendChatInvitationViewModelFactory;
        }

        public ChatViewModel Create(Guid chatId, User user) => new ChatViewModel(chatId, user, _chatApiService, _messageApiService, _sendChatInvitationViewModelFactory);
    }
}
