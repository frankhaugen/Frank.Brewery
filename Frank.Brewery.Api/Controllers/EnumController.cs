using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Frank.Brewery.Api.Controllers
{
    public class EnumController : ControllerBase
    {
        private readonly IMapper _mapper;

        public EnumController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("/enums/BrewTypes")]
        public async Task<IActionResult> GetBrewTypes()
        {
            var codes = Enum.GetValues(typeof(BrewType)).Cast<BrewType>();

            var response = _mapper.Map<List<EnumDto>>(codes);

            return Ok(response);
        }

        [HttpGet("/enums/beercategories")]
        public async Task<IActionResult> GetBeerCategories()
        {
            var codes = Enum.GetValues(typeof(BrewCategory)).Cast<BrewCategory>();

            var response = _mapper.Map<List<EnumDto>>(codes);

            return Ok(response);
        }

        [HttpGet("/enums/amounts")]
        public async Task<IActionResult> GetAmounts()
        {
            var codes = Enum.GetValues(typeof(Amount)).Cast<Amount>();

            var response = _mapper.Map<List<EnumDto>>(codes);

            return Ok(response);
        }

        [HttpGet("/enums/fermentabletypes")]
        public async Task<IActionResult> GetFermentableTypes()
        {
            var codes = Enum.GetValues(typeof(FermentableType)).Cast<FermentableType>();

            var response = _mapper.Map<List<EnumDto>>(codes);

            return Ok(response);
        }

        [HttpGet("/enums/steps")]
        public async Task<IActionResult> GetSteps()
        {
            var codes = Enum.GetValues(typeof(StepName)).Cast<StepName>();

            var response = _mapper.Map<List<EnumDto>>(codes);

            return Ok(response);
        }
    }
}
