﻿using System.Collections.Generic;
using Frank.Brewery.DataTransferObjects;

namespace Frank.Brewery.Services
{
    public interface IEnumService
    {
        List<EnumDto> BrewTypes();
        List<EnumDto> BeerCategories();
        List<EnumDto> Amounts();
        List<EnumDto> FermentableTypes();
        List<EnumDto> StepNames();
    }
}