using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services
{
    public interface IAccountApiService
    {
        public Task<bool> LoginAsync(UserLogin userLogin);
        public Task<bool> RegisterAsync(UserRegister userRegister);
    }
}
