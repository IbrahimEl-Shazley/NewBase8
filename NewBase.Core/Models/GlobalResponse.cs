using System;
using System.Net;

namespace NewBase.Core.Models
{
    public class GlobalResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DevExeptionMessage { get; set; }
        public T Data { get; set; }

        public static GlobalResponse Init()
        {
            return new GlobalResponse();
        }

        public GlobalResponse Success(object data, string successMessage)
        {
            return new GlobalResponse { IsSuccess = true, Data = data, SuccessMessage = successMessage };
        }

        public GlobalResponse BadRequest(string errorMessage)
        {
            return new GlobalResponse { IsSuccess = false, Data = null, ErrorCode = $"{(int)HttpStatusCode.BadRequest} {HttpStatusCode.BadRequest}", ErrorMessage = errorMessage };
        }

        public GlobalResponse Unauthorized(string errorMessage)
        {
            return new GlobalResponse { IsSuccess = false, Data = null, ErrorCode = $"{(int)HttpStatusCode.Unauthorized} {HttpStatusCode.Unauthorized}", ErrorMessage = errorMessage };
        }

        public GlobalResponse Forbidden(string errorMessage)
        {
            return new GlobalResponse { IsSuccess = false, Data = null, ErrorCode = $"{(int)HttpStatusCode.Forbidden} {HttpStatusCode.Forbidden}", ErrorMessage = errorMessage };
        }

        public GlobalResponse InternalServerError(string errorMessage, Exception ex)
        {
            return new GlobalResponse { IsSuccess = false, Data = null, ErrorCode = $"{(int)HttpStatusCode.InternalServerError} {HttpStatusCode.InternalServerError}", ErrorMessage = errorMessage, DevExeptionMessage = ex.ToString() };
        }
    }

    public class GlobalResponse : GlobalResponse<object>
    {

    }
}
