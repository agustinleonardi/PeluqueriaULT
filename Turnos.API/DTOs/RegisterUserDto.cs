using System.ComponentModel.DataAnnotations;

namespace Turnos.API.DTOs;

public class RegisterUserDto
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Name { get; set; } = "";
}