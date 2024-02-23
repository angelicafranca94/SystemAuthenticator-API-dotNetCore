using System.ComponentModel.DataAnnotations;

namespace SystemAuthenticator.API.DTOs;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}