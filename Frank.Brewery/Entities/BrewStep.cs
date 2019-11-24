using System;

namespace Frank.Brewery.Entities
{
    public class BrewStep
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        
        public int StepId { get; set; }
        public Step Step { get; set; }
        public int? ActualAmount { get; set; }

        public int  BrewId { get; set; }
        public Brew Brew { get; set; }
    }
}
