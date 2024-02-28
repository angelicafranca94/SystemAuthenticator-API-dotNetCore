using SystemAuthenticator.Core.DTOs;

namespace SystemAuthenticator.Core.Interfaces.Utils;
public interface IGenerateResponseUtil
{
    NotificationResultDto<T> GenerateResponse<T>(T dto) where T : class;
}
