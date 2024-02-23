using SystemAuthenticator.Core.DTOs;

namespace SystemAuthenticator.Core.Interfaces.Services;
public interface IUserService
{
    Task<NotificationResultDto<UserDto>> AddAsync(UserDto user);
    Task<UserDto> GetByEmailAsync(string email);
    Task<NotificationResultDto<UserDto>> GetByIdAsync(int id);
    Task<NotificationResultDto<UserDto>> UpdateAsync(UserDto userDto);
    Task<IEnumerable<NotificationResultDto<UserDto>>> GetAllAsync();
    Task RemoveAsync(int id);
}
