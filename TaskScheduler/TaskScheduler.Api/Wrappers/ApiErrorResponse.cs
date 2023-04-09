namespace TaskScheduler.Api.Wrappers
{
    public class ApiErrorResponse
    {
        private readonly int _statusCode;
        public string Message { get; set; }

        public ApiErrorResponse(int statusCode)
        {
            _statusCode = statusCode;
            Message = GetApiResponseMessage(_statusCode);
        }

        private static string GetApiResponseMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request",
                401 => "You are not autorized to view this page",
                404 => "The resouce you requested was not found",
                500 => "There was an error in processing",
                _ => "Opps! Something went wrong"
            };
        }
    }
}
