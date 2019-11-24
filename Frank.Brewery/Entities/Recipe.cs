using System;
using System.Collections.Generic;

namespace Frank.Brewery.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public int MashTime { get; set; }
        public int BoilTime { get; set; }
        public int BatchSize { get; set; }

        public IList<RecipeFermentable> RecipeFermentables { get; set; }
        public IList<RecipeHop> RecipeHops { get; set; }


        public Guid? YeastId { get; set; }
        public Yeast? Yeast { get; set; }
        public int YeastAmount { get; set; }

        public IList<Step> Steps { get; set; }
    }
}
