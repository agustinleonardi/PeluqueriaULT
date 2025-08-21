using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs;
using Turnos.Domain.Entities;
using Turnos.Domain.ValueObjects;

namespace Turnos.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task CreateUserAsync(CreateUserDto createUserDto)
    {
        var email = Email.Create(createUserDto.Email);
        var passwordHash = _passwordHasher.Hash(createUserDto.Password);

        var user = new User(createUserDto.Name, email, passwordHash);

        await _userRepository.AddAsync(user);
    }
}