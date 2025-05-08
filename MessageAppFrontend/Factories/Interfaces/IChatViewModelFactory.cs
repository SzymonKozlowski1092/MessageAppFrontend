using MessageAppFrontend.Models;
using MessageAppFrontend.Services.Interfaces;
using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories.Interfaces
{
    public interface IChatViewModelFactory
    {
        ChatViewModel Create(Guid chatId, User user);
    }
}
