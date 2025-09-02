using AutoMapper;
using Turnos.Application.DTOs.Input;
using Turnos.Application.DTOs.Output;
using Turnos.Domain.Entities;

namespace Turnos.Application.Mappers;

public class MappingProfileApplication : Profile
{
    public MappingProfileApplication()
    {
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<Service, ServiceDto>();
    }
}