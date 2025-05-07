using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Models.Dziekanat.Models;
using MessageAppFrontend.Services.Interfaces;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace MessageAppFrontend.Services
{
    public class ChatApiService : IChatApiService
    {
        private readonly RestClient _restClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ChatApiService()
        {
            _restClient = new RestClient("https://localhost:7163/");
        }

        public async Task<ApiResponse<Chat>> GetChat(Guid chatId)
        {
            RestResponse response = null!;
            var request = new RestRequest($"Chat/{chatId}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");
            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse<Chat>(false, 
                        response.ErrorException is null ? response.Content : response.ErrorException.Message, 
                        (int)response.StatusCode);
                }
                var chat = JsonConvert.DeserializeObject<Chat>(response.Content!);
                return new ApiResponse<Chat>(true, chat, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse<Chat>(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }
    }
}
