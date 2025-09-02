using AutoMapper;
using Turnos.Domain.Entities;
using Turnos.Domain.ValueObjects;
using Turnos.Infrastructure.Entities;

namespace Turnos.Infrastructure.Mappers;

public class MappingProfileInfra : Profile
{
    public MappingProfileInfra()
    {
        CreateMap<User, UserEntity>()
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
        .ForMember(dest => dest.Appointments, opt => opt.Ignore());

        CreateMap<UserEntity, User>()
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)))
          .ForMember(dest => dest.Appointments, opt => opt.Ignore());

        CreateMap<Service, ServiceEntity>();
    }
}