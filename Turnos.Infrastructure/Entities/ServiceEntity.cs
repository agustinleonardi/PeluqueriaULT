namespace Turnos.Infrastructure.Entities;

public class ServiceEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int TypeService { get; set; }
    public int Duration { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; } = new List<AppointmentEntity>();

    public ServiceEntity() { }

}