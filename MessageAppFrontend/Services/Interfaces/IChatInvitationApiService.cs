using MessageAppFrontend.Common;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services.Interfaces
{
    public interface IChatInvitationApiService
    {
        Task<ApiResponse<List<ChatInvitation>>> GetActiveChatInvitations();
        Task<ApiResponse> AcceptChatInvitation(Guid chatId);
        Task<ApiResponse> DeclineChatInvitation(Guid chatId);
        Task<ApiResponse> SendChatInvitation(NewChatInvitation chatInvitation);
    }
}
