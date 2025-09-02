using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Data;
using Turnos.Infrastructure.Entities;


namespace Turnos.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public UserRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _dbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task AddAsync(User user)
    {
        var entity = _mapper.Map<UserEntity>(user);
        _dbContext.Users.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        var existingEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if (existingEntity != null)
        {
            _dbContext.Users.Remove(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Users.AnyAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var entities = await _dbContext.Users.ToListAsync();
        return _mapper.Map<IEnumerable<User>>(entities);

    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (entity == null)
        {
            return null;
        }
        return _mapper.Map<User>(entity);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return _mapper.Map<User>(entity);
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetUserCount()
    {
        return await _dbContext.Users.CountAsync();
    }


}