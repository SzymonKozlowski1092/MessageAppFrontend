using MessageAppFrontend.Models;
using MessageAppFrontend.Models.Dziekanat.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;

namespace MessageAppFrontend.Services
{
    public class AccountApiService : IAccountApiService
    {
        private readonly RestClient _restClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public AccountApiService()
        {
            _restClient = new RestClient("https://localhost:7163/");
        }

        public async Task<bool> LoginAsync(UserLogin userLogin)
        {
            try
            {
                var request = new RestRequest("MessageApp/Account/Login", Method.Post);
                request.AddJsonBody(new
                {
                    Username = userLogin.Username,
                    Password = userLogin.Password
                });
                var response = await _restClient.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    var tokenJson = JObject.Parse(response.Content!);
                    AuthToken.Instance.JwtToken = tokenJson["token"]?.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while logging in");
                return false;
            }
        }

        public async Task<bool> RegisterAsync(UserRegister userRegister)
        {
            try
            {
                var request = new RestRequest("MessageApp/Account/Register", Method.Post);
                
                string userRegisterJson = JsonConvert.SerializeObject(userRegister);
                request.AddJsonBody(userRegisterJson);

                var response = await _restClient.ExecuteAsync(request);
                if (response.IsSuccessful)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occurred while registering user");
                return false;
            }
        }
    }
}
