using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Models.Dziekanat.Models;
using RestSharp;

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
