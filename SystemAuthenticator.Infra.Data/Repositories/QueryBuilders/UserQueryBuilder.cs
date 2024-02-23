namespace SystemAuthenticator.Infra.Data.Repositories.QueryBuilders;
public static class UserQueryBuilder
{
    public const string UserExists = @"SELECT *FROM User WHERE Email = @Email";
    public const string Insert = @"INSER INTO User OUTPUT INSERTED.* VALUES (@Name, @Email, @PasswordHash, @PasswordSalt)";
}
