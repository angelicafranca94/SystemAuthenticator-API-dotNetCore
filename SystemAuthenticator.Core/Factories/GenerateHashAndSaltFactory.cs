using System.Security.Cryptography;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Factories;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Factories;
public class GenerateHashAndSaltFactory : IGenerateHashAndSaltFactory
{
    public UserEntity GenerateHashAndSalt(UserDto userDto)
    {
        using var hmac = new HMACSHA512();

        var userEntity = new UserEntity
        {
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userDto.Password)),
            PasswordSalt = hmac.Key
        };

        return userEntity;
    }
}
