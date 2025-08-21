using Turnos.Application.DTOs;
using Turnos.Domain.Entities;

namespace Turnos.Application.Abstractions.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(Guid id);
    Task CreateUserAsync(CreateUserDto createUserDto);
}