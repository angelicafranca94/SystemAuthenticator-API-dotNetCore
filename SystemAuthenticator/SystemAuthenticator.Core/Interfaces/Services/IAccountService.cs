using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Interfaces.Services;
public interface IAccountService
{
    Task<NotificationResultDto<UserDto>> RegisterAsync(UserDto userDto);
    Task<NotificationResultDto<LoginDto>> LoginAsync(LoginDto loginDto);
    Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    Task<UserEntity> UpdateAccountAsync(UpdateAccountDto updateAccountDto);
}
