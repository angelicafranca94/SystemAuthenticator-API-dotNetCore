using System.ComponentModel.DataAnnotations;

namespace SystemAuthenticator.API.DTOs;

public class UpdateAccountDto
{
    public string Username { get; set; }


    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; }
}