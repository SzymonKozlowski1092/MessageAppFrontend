using MessageAppFrontend.Models;

namespace MessageAppFrontend.Services
{
    public interface IAccountService
    {
        public Task<bool> LoginAsync(UserLogin userLogin);
        public Task<bool> RegisterAsync(UserRegister userRegister);
    }
}
