using System;

namespace Frank.Brewery.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Amount { get; set; }
        public string Instructions { get; set; }

        public Guid? HopId { get; set; }
        public Hop? Hop { get; set; }

        public Guid? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
