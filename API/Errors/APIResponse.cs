using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultForStatusCode(statusCode);   // ?? - the null-coalescing operators
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "You are not Authorized",
                404 => "Resource not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}