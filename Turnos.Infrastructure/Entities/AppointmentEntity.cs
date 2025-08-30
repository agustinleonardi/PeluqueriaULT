namespace Turnos.Infrastructure.Entities;

public class AppointmentEntity
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = default!;
    public Guid ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = default!;
    public int Duration { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

}