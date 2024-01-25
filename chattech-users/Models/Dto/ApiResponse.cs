using chattech_users.Models.Entities;

namespace chattech_users.Models.Dto
{
    public class ApiResponse<T> : OperationResult<T>
    {
        public int StatusCode { get; set; }

        public ApiResponse(bool succeeded, string message, T data, int statusCode) : base(succeeded, message, data)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }
    }
}
