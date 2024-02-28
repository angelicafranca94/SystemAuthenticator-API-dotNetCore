using SystemAuthenticator.Core.DTOs;

namespace SystemAuthenticator.Core.Interfaces.Utils;
public interface IVerifierNotificationUtil<T> where T : class
{
    NotificationResultDto<T> Execute(T obj);
}
