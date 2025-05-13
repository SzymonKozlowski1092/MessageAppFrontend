using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using MessageAppFrontend.Models.Dziekanat.Models;
using MessageAppFrontend.Services.Interfaces;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace MessageAppFrontend.Services
{
    public class ChatInvitationApiService : IChatInvitationApiService
    {
        private readonly RestClient _restClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ChatInvitationApiService()
        {
            _restClient = new RestClient("https://localhost:7163/");
        }

        public async Task<ApiResponse<List<ChatInvitation>>> GetActiveChatInvitations()
        {
            RestResponse response = null!;
            var request = new RestRequest("ChatInvitation", Method.Get);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse<List<ChatInvitation>>(false, response.ErrorException is null ? response.Content : response.ErrorException.Message, (int)response.StatusCode);
                }

                var chatInviations = JsonConvert.DeserializeObject<List<ChatInvitation>>(response.Content!);
                return new ApiResponse<List<ChatInvitation>>(true, chatInviations, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse<List<ChatInvitation>>(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }
    }
}
