using System;

namespace Frank.Brewery.Entities
{
    public class RecipeFermentable
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int FermentableId { get; set; }
        public Fermentable Fermentable { get; set; }
    }
}
