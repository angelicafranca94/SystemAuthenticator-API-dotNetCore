using System.Net;

namespace SystemAuthenticator.Core.DTOs;
public class NotificationResultDto<T> where T : class
{
    public NotificationResultDto(bool success, string message, string token, HttpStatusCode httpStatusCode, T data)
    {
        Success = success;
        Message = message;
        Token = token;
        HttpStatusCode = httpStatusCode;
        Data = data;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public string Token { get; private set; }

    public HttpStatusCode HttpStatusCode { get; set; }

    public T Data { get; private set; }
}
