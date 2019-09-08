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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var recipe = builder.Entity<Recipe>();
            recipe.HasKey(d => d.Id);
            recipe.Property(d => d.Id).IsRequired();
            recipe
                .HasMany(r => r.Steps)
                .WithOne(s => s.Recipe)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            var step = builder.Entity<Step>();
            step
                .HasOne(s => s.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
