using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frank.Brewery.Services
{
    public class EnumService : IEnumService
    {
        private readonly IMapper _mapper;

        public EnumService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<EnumDto> BeerTypes()
        {
            var beerTypes = Enum.GetValues(typeof(BeerType)).Cast<BeerType>();

            return _mapper.Map<List<EnumDto>>(beerTypes);
        }

        public List<EnumDto> BeerCategories()
        {
            var beerCategories = Enum.GetValues(typeof(BeerCategory)).Cast<BeerCategory>();

            return _mapper.Map<List<EnumDto>>(beerCategories);
        }

        public List<EnumDto> Amounts()
        {
            var amounts = Enum.GetValues(typeof(Amount)).Cast<Amount>();

            return _mapper.Map<List<EnumDto>>(amounts);
        }

        public List<EnumDto> FermentableTypes()
        {
            var fermentableTypes = Enum.GetValues(typeof(FermentableType)).Cast<FermentableType>();

            return _mapper.Map<List<EnumDto>>(fermentableTypes);
        }

        public List<EnumDto> StepNames()
        {
            var stepNames = Enum.GetValues(typeof(StepName)).Cast<StepName>();

            return _mapper.Map<List<EnumDto>>(stepNames);
        }
    }
}
