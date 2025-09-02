using Turnos.Application.DTOs.Input;
using Turnos.Application.DTOs.Output;

namespace Turnos.Application.Abstractions.Services;

public interface IServiceService
{
    // Define service methods here, for example:
    Task<IEnumerable<ServiceDto>> GetAllAsync();
    Task<ServiceDto> GetByIdAsync(Guid id);
    Task<ServiceDto> AddAsync(CreateServiceDto service);
    Task<bool> UpdateAsync(ServiceDto service);
    Task<bool> DeleteAsync(Guid id);
}
