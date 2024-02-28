using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Interfaces.Factories;
public interface IGenerateHashAndSaltFactory
{
    UserEntity GenerateHashAndSalt(UserDto userDto);
}
