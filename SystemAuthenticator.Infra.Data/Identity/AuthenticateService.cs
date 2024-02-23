using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SystemAuthenticator.Domain.Account;
using SystemAuthenticator.Domain.Entities;
using SystemAuthenticator.Infra.Data.Repositories.QueryBuilders;

namespace SystemAuthenticator.Infra.Data.Identity;
public class AuthenticateService : IAuthenticate
{
    private readonly IDbConnection _dbContext;
    private readonly IConfiguration _configuration;

    public AuthenticateService(IDbConnection dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var user = (await _dbContext.QueryAsync<UserEntity>(UserQueryBuilder.UserExists, new { Email = email })).FirstOrDefault();

        if (user is null) return false;

        using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return false;
        }

        return true;
    }

    public string GenerateToken(int? id, string email)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                       _configuration["Jwt:Issuer"],
                                  _configuration["Jwt:Audience"],
                                             claims,
                                                        expires: DateTime.Now.AddMinutes(30),
                                                                   signingCredentials: credentials
                                                                          );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> UserExists(string email)
    {
        var user = (await _dbContext.QueryAsync<UserEntity>(UserQueryBuilder.UserExists, new { Email = email })).FirstOrDefault();

        if (user is null) return false;

        return true;
    }
}
