using SystemAuthenticator.Core.DTOs;

namespace SystemAuthenticator.Core.Interfaces.Services;
public interface IVerifierService<T> where T : class
{
    NotificationResultDto<T> Execute(T obj);
}
