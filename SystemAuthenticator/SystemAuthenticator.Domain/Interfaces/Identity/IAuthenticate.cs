namespace SystemAuthenticator.Domain.Interfaces.Identity;
public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);

    string GenerateToken(int id, string email, int userRole);
}
