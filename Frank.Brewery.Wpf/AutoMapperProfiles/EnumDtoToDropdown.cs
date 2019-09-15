using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using System.Windows.Controls;
using Frank.Brewery.Extensions;

namespace Frank.Brewery.Wpf.AutoMapperProfiles
{
    public class EnumDtoToDropdown : Profile
    {
        public EnumDtoToDropdown()
        {
            CreateMap<EnumDto, ComboBoxItem>()
                .ForMember(item => item.TabIndex, opt => opt.MapFrom(dto => dto.Value))
                .ForMember(item => item.Content, opt => opt.MapFrom(dto => dto.Name));

            CreateMap<ComboBoxItem, EnumDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(item => item.Content))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(item => item.TabIndex));
        }
    }
}
