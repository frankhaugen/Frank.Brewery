namespace Frank.Brewery.Entities
{
    public class RecipeHop
    {
        public int Id { get; set; }
        public int ReceipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int HopId { get; set; }
        public Hop Hop { get; set; }
    }
}
