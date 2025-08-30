using Turnos.Domain.Entities;

namespace Turnos.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task AddAsync(User user);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> ExistsAsync(Guid id);

    Task<int> GetUserCount();
}