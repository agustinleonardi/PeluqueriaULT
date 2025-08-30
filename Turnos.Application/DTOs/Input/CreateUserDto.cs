namespace Turnos.Application.DTOs;

public sealed record CreateUserDto(string Email, string Password, string Name);