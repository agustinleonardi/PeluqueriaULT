namespace Turnos.Application.Abstractions.Services;

public interface IPasswordHasher
{
    string Hash(string password);

}