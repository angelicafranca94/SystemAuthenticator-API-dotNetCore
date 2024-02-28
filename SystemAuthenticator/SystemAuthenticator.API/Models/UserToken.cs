namespace SystemAuthenticator.API.Models;

public class UserToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}
