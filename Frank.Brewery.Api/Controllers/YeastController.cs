using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Frank.Brewery.DataTransferObjects;
using Frank.Brewery.Entities;
using Frank.Brewery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frank.Brewery.Api.Controllers
{
    public class YeastController : ControllerBase
    {
        private readonly IYeastService _yeastService;
        private readonly IMapper _mapper;

        public YeastController(IYeastService yeastService, IMapper mapper)
        {
            _yeastService = yeastService;
            _mapper = mapper;
        }

        [HttpGet("/yeasts")]
        public async Task<IActionResult> Get()
        {
            var yeasts = await _yeastService.GetAll();
            return Ok(yeasts);
        }

        [HttpPost("/yeasts")]
        public async Task<IActionResult> Insert([FromBody] YeastDto yeast)
        {
            var yeasts = await _yeastService.Add(_mapper.Map<Yeast>(yeast));
            return Ok(yeasts);
        }

        [HttpPut("/yeasts/{yeastId}")]
        public async Task<IActionResult> Update()
        {
            var yeasts = await _yeastService.GetAll();
            return Ok(yeasts);
        }

        [HttpDelete("/yeasts/{yeastId}")]
        public async Task<IActionResult> Remove([FromRoute] Guid yeastId)
        {
            var yeasts = await _yeastService.Remove(yeastId);
            return Ok(yeasts);
        }

        [HttpGet("/yeasts/{yeastId}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid yeastId)
        {
            var yeasts = await _yeastService.GetAll();
            return Ok(yeasts);
        }
    }
}
