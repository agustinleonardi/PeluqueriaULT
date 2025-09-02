using AutoMapper;
using Turnos.API.DTOs;
using Turnos.Application.DTOs;
using Turnos.Application.DTOs.Input;

namespace Turnos.API.Mappers;

public class MappingProfileAPI : Profile
{
    public MappingProfileAPI()
    {
        CreateMap<RegisterUserDto, RegisterUserRequest>().ReverseMap();
        CreateMap<ServiceRequestDto, CreateServiceDto>().ReverseMap();
    }
}