using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Enums;

namespace Frank.Brewery.AutoMapperProfiles
{
    public class EnumToDtoProfile : Profile
    {
        public EnumToDtoProfile()
        {
            CreateMap<BrewType, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.ToString()))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(e => e));

            CreateMap<Amount, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.ToString()))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(e => e));

            CreateMap<FermentableType, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.ToString()))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(e => e));

            CreateMap<StepName, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.ToString()))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(e => e));

            CreateMap<BrewCategory, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.ToString()))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(e => e));

        }
    }
}
