using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlusGame.DataAccess.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
    public class LogInResponse<T>
    {
        public LogInResponse()
        {
        }
        public LogInResponse(T data)
        {
            Succeeded = true;
            IsAccepted = true;
            Message = string.Empty;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public bool IsAccepted { get; set; }
        public string Message { get; set; }
    }
}
