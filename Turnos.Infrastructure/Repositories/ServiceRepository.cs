using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Data;

namespace Turnos.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _dbContext;

    public ServiceRepository(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    public async Task AddAsync(Service service)
    {
        _dbContext.Services.Add(service);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Service service)
    {
        _dbContext.Services.Remove(service);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Services.AnyAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _dbContext.Services.ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Services.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(Service service)
    {
        _dbContext.Services.Update(service);
        await _dbContext.SaveChangesAsync();
    }
}