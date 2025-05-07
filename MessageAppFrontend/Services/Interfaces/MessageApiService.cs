using MessageAppFrontend.Common;
using MessageAppFrontend.Models.Dziekanat.Models;
using MessageAppFrontend.Models;
using NLog;
using RestSharp;

namespace MessageAppFrontend.Services.Interfaces
{
    public class MessageApiService : IMessageApiService
    {
        private readonly RestClient _restClient;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MessageApiService()
        {
            _restClient = new RestClient("https://localhost:7163/");
        }
        
        public async Task<ApiResponse> SendMessage(NewMessage newMessage)
        {
            RestResponse response = null!;
            var request = new RestRequest($"Message", Method.Post);
            request.AddHeader("Authorization", $"Bearer {AuthToken.Instance.JwtToken}");
            request.AddJsonBody(new
            {
                ChatId = newMessage.ChatId,
                Content = newMessage.Content
            });

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
    }
}
