using MessageAppFrontend.Common;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services.Interfaces
{
    public interface IChatApiService
    {
        Task<ApiResponse<Chat>> GetChat(Guid chatId);
        Task<ApiResponse> CreateChat(NewChat newChat);
    }
}
