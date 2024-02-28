using Microsoft.AspNetCore.Mvc;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;

namespace SystemAuthenticator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IEmailService _emailService;

    public AccountController(IAccountService accountService, IEmailService emailService)
    {
        _accountService = accountService;
        _emailService = emailService;

    }

    // Registro
    [HttpPost("Register")]
    public async Task<IActionResult> Post([FromBody] UserDto userDto)
    {
        var result = await _accountService.RegisterAsync(userDto);

        return StatusCode((int)result.HttpStatusCode, result);
    }

    // Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var result = await _accountService.LoginAsync(model);

        return StatusCode((int)result.HttpStatusCode, result);
    }

    // Recuperação de senha
    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
    {
        return Ok();
    }
}

