
using AutoMapper;
using Turnos.Application.Abstractions.Repositories;
using Turnos.Application.Abstractions.Services;
using Turnos.Application.DTOs.Input;
using Turnos.Application.DTOs.Output;
using Turnos.Domain.Entities;

namespace Turnos.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IServiceRepository serviceRepository, IUserRepository userRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        var service = await _serviceRepository.GetByIdAsync(dto.ServiceId);
        if (user == null || service == null)
            throw new Exception("Usuario o servicio no encontrado");
        var appointment = new Appointment(service, user.Id, DateTime.Now, service.Price);
        await _appointmentRepository.AddAsync(appointment);
        return _mapper.Map<AppointmentDto>(appointment);

    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) throw new Exception("Usuario no encontrado");
        var appointments = await _appointmentRepository.GetAllByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _appointmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<bool> CancelAppointmentAsync(Guid appointmentId)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        if (appointment == null) throw new Exception("Turno no existente");
        appointment.Cancel();
        return true;
    }

}
