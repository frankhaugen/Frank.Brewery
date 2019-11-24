using Frank.Brewery.Enums;
using System;

namespace Frank.Brewery.DataTransferObjects
{
    public class YeastDto
    {
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public BrewCategory BrewCategory { get; set; }
        public Amount AlcoholTolerance { get; set; }
        public Amount Flocculation { get; set; }
    }
}
