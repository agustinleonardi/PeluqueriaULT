using System.Text;
using Turnos.Application.Abstractions.Services;
using System.Security.Cryptography;

namespace Turnos.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        var sha = SHA512.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}