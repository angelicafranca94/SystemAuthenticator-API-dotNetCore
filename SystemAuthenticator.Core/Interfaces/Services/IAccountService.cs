using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Interfaces.Services;
public interface IAccountService
{
    Task<UserEntity> RegisterAsync(RegisterDto registerDto);
    Task<UserEntity> LoginAsync(LoginDto loginDto);
    Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    Task<UserEntity> UpdateAccountAsync(UpdateAccountDto updateAccountDto);
}
