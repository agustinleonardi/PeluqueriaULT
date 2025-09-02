using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs;
using Turnos.Domain.Entities;
using Turnos.Domain.Enums;
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

    public async Task CreateUserAsync(RegisterUserRequest dto)
    {
        var email = Email.Create(dto.Email);
        var user = await _userRepository.GetByEmailAsync(email.Value);
        if (user != null) throw new Exception("El usuario con ese email ya existe");
        var passwordHash = _passwordHasher.Hash(dto.Password);
        var newUser = new User(Guid.NewGuid(), dto.Name, email, passwordHash, Role.Client, true, DateTimeOffset.Now, new List<Appointment>());
        await _userRepository.AddAsync(newUser);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<int> GetUserCount()
    {
        return await _userRepository.GetUserCount();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception($"El usuario con la id {id} no existe");
        await _userRepository.DeleteAsync(user);
    }

    public async Task<User?> AuthenticateAsync(string email, string password)
    {
        var emailValidate = Email.Create(email);
        var existingUser = await _userRepository.GetByEmailAsync(emailValidate.Value);
        if (existingUser == null) throw new Exception("El usuario con ese email no existe");

        if (!_passwordHasher.Verify(existingUser.PasswordHash, password)) return null;

        return existingUser;
    }
}