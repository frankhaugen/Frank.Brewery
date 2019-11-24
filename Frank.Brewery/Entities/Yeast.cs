using Frank.Brewery.Enums;
using System;
using System.Collections.Generic;

namespace Frank.Brewery.Entities
{
    public class Yeast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public BrewCategory BrewCategory { get; set; }
        public Amount AlcoholTolerance { get; set; }
        public Amount Flocculation { get; set; }
        public IList<Recipe> Recipes { get; set; }
    }
}
