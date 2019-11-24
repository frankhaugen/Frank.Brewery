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
            var recipe = builder.Entity<Recipe>();
            recipe.HasKey(d => d.Id);
            recipe
                .HasMany(r => r.Steps)
                .WithOne(s => s.Recipe)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            recipe
                .HasMany(r => r.RecipeHops)
                .WithOne(rh => rh.Recipe)
                .HasForeignKey(rh => rh.ReceipeId)
                .OnDelete(DeleteBehavior.Restrict);
            recipe
                .HasMany(r => r.RecipeFermentables)
                .WithOne(rf => rf.Recipe)
                .HasForeignKey(rf => rf.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            recipe
                .HasOne(r => r.Yeast)
                .WithMany(y => y.Recipes)
                .HasForeignKey(r => r.YeastId)
                .OnDelete(DeleteBehavior.Restrict);

            var step = builder.Entity<Step>();
            step.HasKey(s => s.Id);
            step
                .HasOne(s => s.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            step
                .HasOne(s => s.Hop)
                .WithMany(h => h.Steps)
                .HasForeignKey(s => s.HopId)
                .OnDelete(DeleteBehavior.Restrict);

            var hop = builder.Entity<Hop>();
            hop.HasKey(h => h.Id);
            hop
                .HasMany(h => h.RecipeHops)
                .WithOne(rh => rh.Hop)
                .HasForeignKey(rh => rh.HopId)
                .OnDelete(DeleteBehavior.Restrict);
            


        }
    }
}
