using AutoMapper;
using FraudWatch.Application.DTOs;
using FraudWatch.Domain.Entities;

namespace FraudWatch.Application.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AnalistaEntity, AnalistaDTO>().ReverseMap();
        CreateMap<DentistaEntity, DentistaDTO>().ReverseMap();
    }
}
