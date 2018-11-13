using System.Collections.Generic;

namespace BookStore.Shared.RequestResponse
{
    public class ResponseResult
    {
        public ResponseResult(string message, bool success, object data = null, object errors = null)
        {
            Message = message;
            Data = data;
            Success = success;
            Errors = errors;
        }

        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public object Errors { get; set; }
    }
}
