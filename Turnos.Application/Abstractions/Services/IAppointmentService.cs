using Turnos.Application.DTOs.Input;
using Turnos.Application.DTOs.Output;

namespace Turnos.Application.Abstractions.Services;

public interface IAppointmentService
{
    Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserAsync(Guid userId);
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<bool> CancelAppointmentAsync(Guid appointmentId);
}


