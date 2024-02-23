using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Mapper;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Mappings;

public class Mapper : IMapper
{

    public UserEntity MapToUserEntity(UserDto userDto)
    {
        return new UserEntity
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,

        };
    }



    public UserDto MapToUserDto(UserEntity userEntity)
    {
        return new UserDto
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            Email = userEntity.Email
        };
    }


    public IEnumerable<UserDto> MapToUserDto(IEnumerable<UserEntity> userEntity)
    {
        foreach (var user in userEntity)
        {
            yield return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
