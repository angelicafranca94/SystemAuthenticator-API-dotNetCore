using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Core.Services;
public class AccountService : IAccountService
{
    // Implementação dos métodos da interface
    public Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> LoginAsync(LoginDto loginDto)
    {
        // Recupere o hash de senha do banco de dados
        var passwordHash = string.Empty;
        // ...

        // Verifique a senha fornecida com o hash de senha
        bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, passwordHash);
        if (!isValidPassword)
        {
            // A senha fornecida é inválida
            // ...
        }

        // A senha fornecida é válida
        // ...

        throw new NotImplementedException();
    }

    public Task<UserEntity> RegisterAsync(RegisterDto registerDto)
    {
        // Gere um hash de senha com salt
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        // Armazene o hash de senha no banco de dados
        // ...

        throw new NotImplementedException();
    }

    public Task<UserEntity> UpdateAccountAsync(UpdateAccountDto updateAccountDto)
    {
        throw new NotImplementedException();
    }
}

