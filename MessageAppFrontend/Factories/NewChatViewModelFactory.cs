using MessageAppFrontend.Factories.Interfaces;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories
{
    public class NewChatViewModelFactory : INewChatViewModelFactory
    {
        private readonly IChatApiService _chatApiService;

        public NewChatViewModelFactory(IChatApiService chatApiService)
        {
            _chatApiService = chatApiService;
        }

        public NewChatViewModel CreateNewChatViewModel(Guid userId) => new NewChatViewModel(userId, _chatApiService);
    }
}
