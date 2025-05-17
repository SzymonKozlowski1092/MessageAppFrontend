using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Models.Dziekanat.Models;
using MessageAppFrontend.Services.Interfaces;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace MessageAppFrontend.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly RestClient _restClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UserApiService()
        {
            _restClient = new RestClient("https://localhost:7163/");
        }

        public async Task<ApiResponse<User>> GetUser()
        {
            RestResponse response = null!;
            var request = new RestRequest("User", Method.Get);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse<User>(false, response.Content, (int)response.StatusCode);
                }
                var user = JsonConvert.DeserializeObject<User>(response.Content!);

                return new ApiResponse<User>(true, user, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse<User>(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }

        public async Task<ApiResponse<User>> GetUserByUsername(string username)
        {
            RestResponse response = null!;
            var request = new RestRequest($"{username}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse<User>(false, response.Content, (int)response.StatusCode);
                }
                var user = JsonConvert.DeserializeObject<User>(response.Content!);

                return new ApiResponse<User>(true, user, (int)response.StatusCode);
            }
            catch (Exception ex) 
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse<User>(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }

        public async Task<ApiResponse<List<SimpleChat>>> GetUserChats()
        {
            RestResponse response = null!;
            var request = new RestRequest("User/SimpleChats", Method.Get);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse<List<SimpleChat>>(false, response.Content, (int)response.StatusCode);
                }
                var chats = JsonConvert.DeserializeObject<List<SimpleChat>>(response.Content!);
                return new ApiResponse<List<SimpleChat>>(true, chats, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse<List<SimpleChat>>(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }
    }
}
