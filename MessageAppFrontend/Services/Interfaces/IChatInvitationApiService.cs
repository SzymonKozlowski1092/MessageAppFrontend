using MessageAppFrontend.Common;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services.Interfaces
{
    public interface IChatInvitationApiService
    {
        Task<ApiResponse<List<ChatInvitation>>> GetActiveChatInvitations();
    }
}
