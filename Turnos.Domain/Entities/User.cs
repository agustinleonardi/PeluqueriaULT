using PeluqueriaUlt.Domain.Enums;
using Turnos.Domain.ValueObjects;

namespace Turnos.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public Role Role { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    private User() { }

    public User(string name, Email email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = Role.Client;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        Appointments = new List<Appointment>();
    }
}