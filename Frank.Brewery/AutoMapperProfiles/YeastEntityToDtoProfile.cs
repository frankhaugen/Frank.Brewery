using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Entities;

namespace Frank.Brewery.AutoMapperProfiles
{
    public class YeastEntityToDtoProfile : Profile
    {
        public YeastEntityToDtoProfile()
        {
            CreateMap<YeastDto, Yeast>();
            CreateMap<Yeast, YeastDto>();
        }
    }
}
