using Microsoft.AspNetCore.Mvc;
using SystemAuthenticator.API.Models;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Domain.Account;

namespace SystemAuthenticator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthenticate _authenticateService;
    private readonly IUserService _userService;

    public AccountController(IAuthenticate authenticateService, IUserService userService)
    {
        _authenticateService = authenticateService;
        _userService = userService;
    }

    // Registro
    [HttpPost("register")]
    public async Task<ActionResult<UserToken>> Post([FromBody]UserDto userDto)
    {
        var user = await _userService.AddAsync(userDto);
        var token = _authenticateService.GenerateToken(user.Data.Id, user.Data.Email);
        return Ok(new UserToken { Token = token });
    }

    //// Login
    //[HttpPost("Login")]
    //public async Task<IActionResult> Login(LoginDto model)
    //{
    //    return Ok();
    //}

    //// Recuperação de senha
    //[HttpPost("ForgotPassword")]
    //public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
    //{
    //    return Ok();
    //}

    //// Gerenciamento de conta
    //[HttpGet("GetAccount")]
    //public async Task<IActionResult> GetAccount()
    //{
    //    return Ok();
    //}

    //[HttpPut("UpdateAccount")]
    //public async Task<IActionResult> UpdateAccount(UpdateAccountDto model)
    //{
    //    return Ok();
    //}

    //[HttpDelete("DeleteAccount")]
    //public async Task<IActionResult> DeleteAccount()
    //{
    //    return Ok();
    //}
}

