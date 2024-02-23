using System.ComponentModel.DataAnnotations;

namespace SystemAuthenticator.API.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Username { get; set; }
}
