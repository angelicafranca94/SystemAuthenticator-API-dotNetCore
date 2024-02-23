using SystemAuthenticator.Core.DTOs;

namespace SystemAuthenticator.Core.Interfaces.Services;
public interface IUserService
{
    Task<NotificationResultDto<UserDto>> AddAsync(UserDto user);
    Task<UserDto> GetByEmail(string email);
    Task<UserDto> GetById(Guid id);
    Task Update(UserDto user);
    Task<IEnumerable<UserDto>> GetAll();
    Task Remove(Guid id);
    Task<bool> Exists(Guid id);
    Task<bool> Exists(string email);
}
