using System;

namespace Frank.Brewery.Entities
{
    public class RecipeFermentable
    {
        public int Id { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid FermentableId { get; set; }
        public Fermentable Fermentable { get; set; }
    }
}
