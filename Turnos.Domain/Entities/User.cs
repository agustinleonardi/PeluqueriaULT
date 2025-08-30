using Turnos.Domain.Enums;
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
    public DateTimeOffset CreatedAtUtc { get; private set; }

    private readonly List<Appointment> _appointments = new List<Appointment>();
    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();
    private User() { }

    public void Desactivate() => IsActive = false;
    public void Activate() => IsActive = true;
    public User(Guid id, string name, Email email, string passwordHash, Role role, bool active, DateTimeOffset dateTimeOffset)
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
        CreatedAtUtc = DateTimeOffset.UtcNow;
        _appointments = new List<Appointment>();
    }
}