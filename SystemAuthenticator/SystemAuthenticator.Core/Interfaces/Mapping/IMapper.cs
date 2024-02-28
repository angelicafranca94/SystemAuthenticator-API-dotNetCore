using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Interfaces.Mapper;
public interface IMapper
{
    IEnumerable<UserDto> MapToUserDto(IEnumerable<UserEntity> userEntity);
    UserDto MapToUserDto(UserEntity userEntity);
    UserEntity MapToUserEntity(UserDto userDto);
}
