using MessageAppFrontend.Common;
using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services.Interfaces
{
     public interface IUserApiService
    {
        public Task<ApiResponse<User>> GetUser();
        public Task<ApiResponse<User>> GetUserByUsername(string username);
        public Task<ApiResponse<List<SimpleChat>>>GetUserChats();
    }
}
