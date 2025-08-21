using Microsoft.AspNetCore.Mvc;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs;

namespace Turnos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet("todos")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetUserCount()
    {
        var count = await _userService.GetUserCount();
        return Ok(count);
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        await _userService.CreateUserAsync(createUserDto);
        return Ok("Usuario creado con exito");
    }
}