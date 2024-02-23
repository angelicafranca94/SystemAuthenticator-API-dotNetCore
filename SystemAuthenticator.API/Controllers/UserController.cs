using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Services;

namespace SystemAuthenticator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Post([FromBody] UserDto user)
    {
        var result = await _userService.AddAsync(user);
        return StatusCode((int)result.HttpStatusCode, result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserDto user)
    {
        var result = await _userService.UpdateAsync(user);
        return StatusCode((int)result.HttpStatusCode, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _userService.GetByIdAsync(id);
        return StatusCode((int)result.HttpStatusCode, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _userService.GetAllAsync();
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.RemoveAsync(id);
        return Ok();
    }
}
