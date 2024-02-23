namespace SystemAuthenticator.Core.DTOs;
public class NotificationResultDto<T> where T : class
{
    public NotificationResultDto(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }
}
