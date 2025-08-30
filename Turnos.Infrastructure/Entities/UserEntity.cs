using Microsoft.EntityFrameworkCore.Storage;

namespace Turnos.Infrastructure.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public int Role { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();
    public UserEntity() { }

}