using Turnos.Domain.Enums;

namespace Turnos.Domain.Entities;

public class Service
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public TypeService TypeService { get; private set; }
    public int Duration { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Service() { }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public Service(string name, TypeService typeService, decimal price, int duration)
    {
        Id = Guid.NewGuid();
        Name = name;
        TypeService = typeService;
        Price = price;
        CreatedAt = DateTime.UtcNow;
        Duration = duration;
    }
}