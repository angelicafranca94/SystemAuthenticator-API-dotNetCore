using FluentValidator;
using FluentValidator.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemAuthenticator.Core.DTOs;
public class UserDto  : Notifiable
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [NotMapped]
    public string Password { get; set; }

    //public UserDto()
    //{

    //}

    //public UserDto(int? id, string name, string email, string password)
    //{
    //    Id = id;
    //    Name = name;
    //    Email = email;
    //    Password = password;

    //    AddNotifications(new ValidationContract()
    //   .Requires()

    //   .IsNotNullOrEmpty(Name, "Name", "Name is required")
    //   .HasMaxLen(Name, 250, "Name", "Name must contain up to 250 characters")

    //   .IsNotNullOrEmpty(Email, "Email", "Email is required")
    //   .HasMaxLen(Email, 200, "Email", "Email must contain up to 200 characters")

    //   .IsNotNullOrEmpty(Password, "Password", "Password is required")
    //   .HasMaxLen(Password, 100, "Password", "Password must contain up to 100 characters")
    //   .HasMinLen(Password, 8, "Password", "Password must contain down to 8 characters"));
    //}

    //public UserDto()
    //{
    //    AddNotifications(new ValidationContract()
    //   .Requires()

    //   .IsNotNullOrEmpty(Name, "Name", "Name is required")
    //   .HasMaxLen(Name, 250, "Name", "Name must contain up to 250 characters")

    //   .IsNotNullOrEmpty(Email, "Email", "Email is required")
    //   .HasMaxLen(Email, 200, "Email", "Email must contain up to 200 characters")

    //   .IsNotNullOrEmpty(Password, "Password", "Password is required")
    //   .HasMaxLen(Password, 100, "Password", "Password must contain up to 100 characters")
    //   .HasMinLen(Password, 8, "Password", "Password must contain down to 8 characters"));
    //}
}
