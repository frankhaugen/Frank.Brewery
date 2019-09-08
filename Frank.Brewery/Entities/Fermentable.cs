using System;
using System.Collections.Generic;

namespace Frank.Brewery.Entities
{
    public class Fermentable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double Lovibond { get; set; }
        public int Ppg { get; set; }

        private IList<RecipeFermentable> Recipes { get; set; }
    }
}
