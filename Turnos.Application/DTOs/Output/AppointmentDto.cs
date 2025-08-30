
namespace Turnos.Application.DTOs.Output;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = default!;
    public Guid ServiceId { get; set; }
    public string ServiceName { get; set; } = default!;
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
}