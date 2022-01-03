using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessageForStatusCode(statusCode); //?? means if message is null then take value from variable that is located right to question mark
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400=>"a bad request you have made",
                401=>"Authorized, you are not",
                404=>"Resource Found, it was not",
                500=>"Errors are the path to the dark side. Errors lead to anger",
                _=>null

            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}