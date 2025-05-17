using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories.Interfaces
{
    public interface ISendChatInvitationViewModelFactory
    {
        public SendChatInvitationViewModel Create(Guid chatId);
    }
}
