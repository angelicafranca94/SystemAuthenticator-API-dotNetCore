using Microsoft.AspNetCore.Mvc;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;

namespace SystemAuthenticator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto user)
    {
        return Ok(await _userService.AddAsync(user));
    }

}
