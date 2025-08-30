
namespace Turnos.Application.DTOs.Input;

public sealed record CreateAppointmentDto
{
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime Date { get; set; }
}