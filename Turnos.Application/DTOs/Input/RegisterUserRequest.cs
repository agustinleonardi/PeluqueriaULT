namespace Turnos.Application.DTOs;

public class RegisterUserRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }

    public RegisterUserRequest() { }

}
