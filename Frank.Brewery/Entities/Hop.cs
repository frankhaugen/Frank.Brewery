using System;
using System.Collections.Generic;

namespace Frank.Brewery.Entities
{
    public class Hop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double AlphaAcid { get; set; }

        public IList<Step> Steps { get; set; }
        public IList<RecipeHop> RecipeHops { get; set; }
    }
}
