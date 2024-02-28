
using FluentValidator;
using FluentValidator.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SystemAuthenticator.Core.DTOs;
public class UserDto : Notifiable, Interfaces.Utils.IValidatableUtil
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [NotMapped]
    public string Password { get; set; }

    [JsonIgnore]
    public bool IsAdmin { get; set; }

    public void Validate()
    {
        AddNotifications(new ValidationContract()
       .Requires()

       .IsNotNullOrEmpty(Name, "Name", "Name is required")
       .HasMaxLen(Name, 250, "Name", "Name must contain up to 250 characters")

       .IsNotNullOrEmpty(Email, "Email", "Email is required")
       .HasMaxLen(Email, 200, "Email", "Email must contain up to 200 characters")

       .IsNotNullOrEmpty(Password, "Password", "Password is required")
       .HasMaxLen(Password, 100, "Password", "Password must contain up to 100 characters")
       .HasMinLen(Password, 8, "Password", "Password must contain down to 8 characters"));
    }

}
