using Turnos.Domain.Entities;

namespace Turnos.Application.Abstractions.Repositories
{
    public interface IServiceRepository
    {
        Task<Service?> GetByIdAsync(Guid id);
        Task<IEnumerable<Service>> GetAllAsync();
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(Service service);
        Task<bool> ExistsAsync(Guid id);

    }
}