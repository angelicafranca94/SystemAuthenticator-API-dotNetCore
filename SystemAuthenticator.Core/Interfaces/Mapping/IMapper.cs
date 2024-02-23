using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Interfaces.Mapper;
public interface IMapper
{
    UserDto MapToUserDto(UserEntity userEntity);
    UserEntity MapToUserEntity(UserDto userDto);
    IEnumerable<UserDto> MapToUserDto(IEnumerable<UserEntity> userEntity);
}
