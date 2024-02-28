using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SystemAuthenticator.Domain.Enums;
using SystemAuthenticator.Domain.Interfaces.Identity;
using SystemAuthenticator.Domain.Interfaces.Repositories;

namespace SystemAuthenticator.Infra.Data.Identity;
public class AuthenticateService : IAuthenticate
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthenticateService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null) return false;

        using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return false;
        }

        return true;
    }

    public string GenerateToken(int id, string email, int userRole)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, GetRoleUser(userRole)),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                       _configuration["JwtSettings:Issuer"],
                                  _configuration["JwtSettings:Audience"],
                                             claims,
                                                        expires: DateTime.Now.AddMinutes(30),
                                                                   signingCredentials: credentials
                                                                          );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GetRoleUser(int userRole)
    {
        return Enum.Parse(typeof(RolesUsers), userRole.ToString()).ToString()!;
    }
}
