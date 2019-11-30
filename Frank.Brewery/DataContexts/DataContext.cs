using Frank.Brewery.DataContexts.EntityConfigurations;
using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;

namespace Frank.Brewery.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Fermentable> Fermentables { get; set; }
        public DbSet<Yeast> Yeasts { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Hop> Hops { get; set; }
        public DbSet<Brew> Brews { get; set; }


        public DbSet<RecipeHop> RecipeHops { get; set; }
        public DbSet<RecipeFermentable> RecipeFermentables { get; set; }
        public DbSet<BrewStep> BrewSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrewConfiguration());
            builder.ApplyConfiguration(new FermentableConfiguration());
            builder.ApplyConfiguration(new HopConfiguration());
            builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new StepConfiguration());
            builder.ApplyConfiguration(new YeastConfiguration());
        }
    }
}
