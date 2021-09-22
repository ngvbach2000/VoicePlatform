using System.Collections;
using VoicePlatform.Utilities.Constants;

namespace VoicePlatform.Data.Application
{
    public class Response
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }
        public int? TotalRow { get; set; } = 0;

        public object Data { get; set; } = 0;


        public static Response OK()
        {
            return new Response
            {
                StatusCode = AppStatusCode.OK
            };
        }

        public static Response OK(object data, int? totalRow = 0)
        {
            if (data is ICollection d)
            {
                totalRow = d.Count;
            }

            return new Response
            {
                Message = "Success",
                StatusCode = AppStatusCode.OK,
                Data = data,
                TotalRow = totalRow
            };
        }

        public static Response NotFound()
        {
            return new Response
            {
                StatusCode = AppStatusCode.NotFound
            };
        }

        public static Response NotFound(string message = null)
        {
            return new Response
            {
                Message = message,
                StatusCode = AppStatusCode.NotFound
            };
        }

        public static Response BadRequest(string message = null)
        {
            return new Response
            {
                Message = message,
                StatusCode = AppStatusCode.BadRequest
            };
        }

        public static Response Unauthorized()
        {
            return new Response
            {
                Message = "Unauthorized",
                StatusCode = AppStatusCode.Unauthorized
            };
        }

        public static Response Forbidden()
        {
            return new Response
            {
                Message = "Forbidden",
                StatusCode = AppStatusCode.Forbidden
            };
        }
    }
}
