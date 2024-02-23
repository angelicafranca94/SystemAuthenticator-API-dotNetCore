namespace SystemAuthenticator.Domain.Account;
public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);

    string GenerateToken(int id, string email, bool isAdmin);
}
