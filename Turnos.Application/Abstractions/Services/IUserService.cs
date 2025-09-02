using Turnos.Application.DTOs;
using Turnos.Domain.Entities;

namespace Turnos.Application.Abstractions.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(Guid id);
    Task CreateUserAsync(RegisterUserRequest createUserDto);
    Task<IEnumerable<User>> GetAllUsers();
    Task<int> GetUserCount();
    Task DeleteAsync(Guid id);
    Task<User?> AuthenticateAsync(string email, string password);
}