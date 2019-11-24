using System;
using System.Collections.Generic;
using System.Text;

namespace Frank.Brewery.DataTransferObjects
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public int MashTime { get; set; }
        public int BoilTime { get; set; }
        public int BatchSize { get; set; }
        public List<FermentableDto> Fermentables { get; set; }
        public YeastDto Yeast { get; set; }
        public List<StepDto> Steps { get; set; }
    }
}
