using AutoMapper;
using Turnos.Domain.Entities;
using Turnos.Infrastructure.Entities;

namespace Turnos.Infrastructure.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>().ReverseMap();
    }
}