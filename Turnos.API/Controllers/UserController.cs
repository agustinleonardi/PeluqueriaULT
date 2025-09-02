using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Turnos.API.DTOs;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs;

namespace Turnos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
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
    public async Task<IActionResult> CreateUser([FromBody] RegisterUserDto registerUserDto)
    {
        var request = _mapper.Map<RegisterUserRequest>(registerUserDto);
        await _userService.CreateUserAsync(request);
        return Ok("Usuario creado con exito");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromBody] Guid id)
    {
        await _userService.DeleteAsync(id);
        return Ok("Usuario eliminado con exito");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        var user = await _userService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
        if (user == null) return Unauthorized("Credenciales invalidas");

        return Ok(user);
    }
}