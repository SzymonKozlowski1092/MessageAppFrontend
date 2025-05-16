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

        public async Task<ApiResponse> AcceptChatInvitation(Guid chatId)
        {
            RestResponse response = null!;
            var request = new RestRequest($"ChatInvitation/AcceptInvitation/{chatId}", Method.Put);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse(false,
                        response.ErrorException is null ? response.Content : response.ErrorException.Message,
                        (int)response.StatusCode);
                }

                return new ApiResponse(true, (int)response.StatusCode);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }

        public async Task<ApiResponse> DeclineChatInvitation(Guid chatId)
        {
            RestResponse response = null!;
            var request = new RestRequest($"ChatInvitation/DeclineInvitation/{chatId}", Method.Put);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    return new ApiResponse(false,
                        response.ErrorException is null ? response.Content : response.ErrorException.Message,
                        (int)response.StatusCode);
                }

                return new ApiResponse(true, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }

        public async Task<ApiResponse> SendChatInvitation(NewChatInvitation chatInvitation)
        {
            RestResponse response = null!;
            var request = new RestRequest("ChatInvitation", Method.Post);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");

            try
            {
                request.AddJsonBody(new
                {
                    ChatId = chatInvitation.ChatId,
                    InvitedUserId = chatInvitation.InvitedUserId,
                });
                response = await _restClient.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    return new ApiResponse(false,
                         response.ErrorException is null ? response.Content : response.ErrorException.Message,
                         (int)response.StatusCode);
                }

                return new ApiResponse(true, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new ApiResponse(false, ex.Message, response is null ? 0 : (int)response!.StatusCode);
            }
        }
    }
}
