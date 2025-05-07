namespace MessageAppFrontend.Common
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public ApiResponse()
        {
            IsSuccess = false;
            ErrorMessage = null;
            StatusCode = 0;
            Data = default;
        }

        /// <summary>
        /// Constructor for failed response
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(bool isSuccess, string? errorMessage, int statusCode)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Constructor for successful response with data
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(bool isSuccess, T? data, int statusCode)
        {
            IsSuccess = isSuccess;
            Data = data;
            StatusCode = statusCode;
        }
    }
    public class ApiResponse : ApiResponse<object?>
    {
        /// <summary>
        /// Constructor for failed response
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(bool isSuccess, string? errorMessage, int statusCode) : base(isSuccess, errorMessage, statusCode)
        {
        }

        /// <summary>
        /// Constructor for successful response when it is not necessary to return an object
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(bool isSuccess, int statusCode)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }
    }
}
