using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Data;
using Turnos.Infrastructure.Data.Persistence;
using Turnos.Infrastructure.Entities;

namespace Turnos.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public ServiceRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _dbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(Service service)
    {
        var ServiceEntity = _mapper.Map<ServiceEntity>(service);
        _dbContext.Services.Add(ServiceEntity);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Service service)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Service>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Service?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Service service)
    {
        throw new NotImplementedException();
    }
}