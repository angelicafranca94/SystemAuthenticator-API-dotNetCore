using System.Net;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Utils;

namespace SystemAuthenticator.Infra.Ioc.Utils;
public class GenerateResponseUtil : IGenerateResponseUtil
{
    public NotificationResultDto<T> GenerateResponse<T>(T dto) where T : class
    {
        return new NotificationResultDto<T>(true, "Success", string.Empty, HttpStatusCode.OK, dto);
    }
}
