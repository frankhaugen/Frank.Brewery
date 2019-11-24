using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frank.Brewery.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Frank.Brewery.Api.Controllers
{
    public class RecipesController : ControllerBase
    {
        [HttpGet("/recipes")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new RecipeDto()
            {
                Fermentables = new List<FermentableDto>(),
                Steps = new List<StepDto>(),
                Yeast = new YeastDto()
            });
        }
    }
}
