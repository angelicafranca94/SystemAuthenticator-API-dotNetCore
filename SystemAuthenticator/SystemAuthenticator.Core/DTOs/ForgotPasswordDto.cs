using FluentValidator;
using FluentValidator.Validation;

namespace SystemAuthenticator.Core.DTOs;
public class ForgotPasswordDto : Notifiable, Interfaces.Utils.IValidatableUtil
{
    public string Email { get; set; }

    public void Validate()
    {
        AddNotifications(new ValidationContract()
           .Requires()
           .IsNotNullOrEmpty(Email, "Email", "Email is required"));
    }
}
