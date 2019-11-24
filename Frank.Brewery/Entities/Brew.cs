using System;
using System.Collections.Generic;
using System.Text;

namespace Frank.Brewery.Entities
{
    public class Brew
    {
        public int Id { get; set; }
        public string? Name => Recipe.Name;
        public DateTime StartDate { get; set; }


        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public IList<BrewStep> BrewSteps { get; set; }
    }
}
