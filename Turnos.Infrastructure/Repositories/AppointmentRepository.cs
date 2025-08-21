using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Data;

namespace Turnos.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _dbContext;

    public AppointmentRepository(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    public async Task AddAsync(Appointment appointment)
    {
        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        _dbContext.Appointments.Remove(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Appointments.AnyAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _dbContext.Appointments.ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _dbContext.Appointments.Update(appointment);
        await _dbContext.SaveChangesAsync();
    }
}