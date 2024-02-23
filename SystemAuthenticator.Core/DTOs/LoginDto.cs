using FluentValidator;
using FluentValidator.Validation;

namespace SystemAuthenticator.Core.DTOs;
public class LoginDto : Notifiable, Interfaces.Utils.IValidatableUtil
{
    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new ValidationContract()
            .Requires()
            .IsNotNullOrEmpty(Email, "Email", "Email is required")
            .IsNotNullOrEmpty(Password, "Password", "Password is required"));
    }

}
