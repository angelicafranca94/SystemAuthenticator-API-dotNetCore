namespace SystemAuthenticator.Infra.Data.Repositories.QueryBuilders;
public static class UserQueryBuilder
{
    public const string Insert = @"INSERT INTO UserSystem OUTPUT INSERTED.* VALUES (@Name, @Email, @PasswordHash, @PasswordSalt, @RoleUser)";
    public const string GetByEmail = @"SELECT *FROM UserSystem WHERE Email = @Email";
    public const string GetById = @"SELECT *FROM UserSystem WHERE Id = @Id";
    public const string Delete = @"DELETE FROM UserSystem WHERE Id = @Id";
    public const string Update = @"UPDATE UserSystem SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, RoleUser = @RoleUser WHERE Id = @Id";
    public const string GetAll  = @"SELECT * FROM UserSystem";
}
