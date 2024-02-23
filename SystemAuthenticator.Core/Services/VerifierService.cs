using FluentValidator;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;

namespace SystemAuthenticator.Core.Services;
public class VerifierService<T> : Notifiable, IVerifierService<T> where T : Notifiable
{
    public NotificationResultDto<T> Execute(T obj)
    {
        return Verify(obj);
    }

    private NotificationResultDto<T> Verify(T obj)
    {
        AddNotifications(obj.Notifications);

        if (Invalid) return new NotificationResultDto<T>(false, "Please validate following fields", (T)Notifications);

        return new NotificationResultDto<T>(true, "Success", obj);
    }
}
