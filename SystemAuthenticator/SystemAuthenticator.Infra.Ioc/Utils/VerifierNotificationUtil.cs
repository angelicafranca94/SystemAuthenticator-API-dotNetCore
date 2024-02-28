using FluentValidator;
using System.Net;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Utils;
using SystemAuthenticator.Infra.Helpers.Constants;

namespace SystemAuthenticator.Infra.Ioc.Utils;
public class VerifierNotificationUtil<T> : Notifiable, IVerifierNotificationUtil<T> where T : Notifiable, IValidatableUtil
{
    public NotificationResultDto<T> Execute(T obj)
    {
        obj.Validate();
        return Verify(obj);
    }

    private NotificationResultDto<T> Verify(T obj)
    {
        AddNotifications(obj.Notifications);

        if (Invalid) return new NotificationResultDto<T>(false, NotificationsConstants.ValidateFields, string.Empty, HttpStatusCode.BadRequest, obj);

        return new NotificationResultDto<T>(true, "Success", string.Empty, HttpStatusCode.OK, obj);
    }
}
