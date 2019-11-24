using System;

namespace Frank.Brewery.DataTransferObjects
{
    public class HopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double AlphaAcid { get; set; }
    }
}
