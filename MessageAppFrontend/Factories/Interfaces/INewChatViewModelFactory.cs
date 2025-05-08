using MessageAppFrontend.ViewModel;

namespace MessageAppFrontend.Factories.Interfaces
{
    public interface INewChatViewModelFactory
    {
        NewChatViewModel CreateNewChatViewModel(Guid userId);
    }
}
