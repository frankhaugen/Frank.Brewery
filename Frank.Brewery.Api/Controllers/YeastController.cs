using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Entities;
using Frank.Brewery.Repositories;
using Frank.Brewery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frank.Brewery.Api.Controllers
{
    public class YeastController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IYeastRepository _yeastRepository;

        public YeastController(IMapper mapper, IYeastRepository yeastRepository)
        {
            _mapper = mapper;
            _yeastRepository = yeastRepository;
        }

        [HttpGet("/yeasts")]
        public async Task<IActionResult> Get()
        {
            var yeasts = await _yeastRepository.GetAll();
            return Ok(yeasts);
        }

        [HttpPost("/yeasts")]
        public async Task<IActionResult> Insert([FromBody] YeastDto yeast)
        {
            var yeasts = await _yeastRepository.Add(_mapper.Map<Yeast>(yeast));
            return Ok(yeasts);
        }

        [HttpPut("/yeasts/{yeastId}")]
        public async Task<IActionResult> Update()
        {
            var yeasts = await _yeastRepository.GetAll();
            return Ok(yeasts);
        }

        [HttpDelete("/yeasts/{yeastId}")]
        public async Task<IActionResult> Remove([FromRoute] int yeastId)
        {
            var yeasts = await _yeastRepository.Remove(yeastId);
            return Ok(yeasts);
        }

        [HttpGet("/yeasts/{yeastId}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid yeastId)
        {
            var yeasts = await _yeastRepository.GetAll();
            return Ok(yeasts);
        }
    }
}
