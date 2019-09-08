using System;

namespace Frank.Brewery.Entities
{
    public class Hop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double AlphaAcid { get; set; }
    }
}
