
using Turnos.Application.Abstractions.Services;
using BCrypt.Net;

namespace Turnos.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string passwordHash, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
