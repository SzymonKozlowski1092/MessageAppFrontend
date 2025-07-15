using MessageAppFrontend.Common;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services.Interfaces
{
    public interface IChatInvitationApiService
    {
        Task<ApiResponse<List<ChatInvitation>>> GetActiveChatInvitations();
        Task<ApiResponse> AcceptChatInvitation(Guid invitationId);
        Task<ApiResponse> DeclineChatInvitation(Guid invitationId);
        Task<ApiResponse> SendChatInvitation(NewChatInvitation chatInvitation);
    }
}
