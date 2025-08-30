using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Data;
using Turnos.Infrastructure.Entities;

namespace Turnos.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public AppointmentRepository(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Appointment> AddAsync(Appointment appointment)
    {
        var entity = _mapper.Map<AppointmentEntity>(appointment);
        _dbContext.Appointments.Add(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Appointment>(entity);
    }

    public async Task DeleteAsync(Appointment appointment)
    {
        var entity = _mapper.Map<AppointmentEntity>(appointment);
        _dbContext.Appointments.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Appointments.AnyAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        var entities = await _dbContext.Appointments.ToListAsync();
        return _mapper.Map<IEnumerable<Appointment>>(entities);
    }

    public async Task<IEnumerable<Appointment>> GetAllByUserIdAsync(Guid userId)
    {
        var entities = await _dbContext.Appointments.Where(a => a.UserId == userId).ToListAsync();

        return _mapper.Map<IEnumerable<Appointment>>(entities);
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        var entity = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        return entity == null ? null : _mapper.Map<Appointment>(entity);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        var entity = _mapper.Map<AppointmentEntity>(appointment);
        _dbContext.Appointments.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}