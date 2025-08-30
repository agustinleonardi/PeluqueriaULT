using Turnos.Domain.Enums;

namespace Turnos.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Service? Service { get; private set; }
    public Guid ServiceId { get; private set; }
    public User? Client { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime Date { get; private set; }
    public int Duration { get; private set; }
    public decimal Price { get; private set; }
    public AppointmentStatus Status { get; private set; } = AppointmentStatus.Avtice;

    public DateTime CreatedAt { get; private set; }

    private Appointment() { }

    public Appointment(Service service, Guid clientId, DateTime date, decimal price)
    {
        Id = Guid.NewGuid();
        ServiceId = service.Id;
        UserId = clientId;
        Date = date;
        Duration = service.Duration;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Status = AppointmentStatus.Cancelled;
    }
}