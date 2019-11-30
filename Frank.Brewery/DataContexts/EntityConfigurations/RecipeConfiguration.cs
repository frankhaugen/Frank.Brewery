using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(d => d.Id);
            builder
                .HasMany(r => r.Steps)
                .WithOne(s => s.Recipe)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(r => r.RecipeHops)
                .WithOne(rh => rh.Recipe)
                .HasForeignKey(rh => rh.ReceipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(r => r.RecipeFermentables)
                .WithOne(rf => rf.Recipe)
                .HasForeignKey(rf => rf.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(r => r.Yeast)
                .WithMany(y => y.Recipes)
                .HasForeignKey(r => r.YeastId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
