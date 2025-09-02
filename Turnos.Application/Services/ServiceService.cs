using AutoMapper;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs.Input;
using Turnos.Application.DTOs.Output;
using Turnos.Domain.Entities;

namespace Turnos.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto> AddAsync(CreateServiceDto dto)
    {
        var service = new Service(dto.Name, dto.TypeService, dto.Price, dto.Duration);

        await _serviceRepository.AddAsync(service);

        return _mapper.Map<ServiceDto>(service);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var service = await _serviceRepository.GetByIdAsync(id);
        if (service == null) return false;
        await _serviceRepository.DeleteAsync(service);
        return true;

    }

    public Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ServiceDto service)
    {
        throw new NotImplementedException();
    }
}