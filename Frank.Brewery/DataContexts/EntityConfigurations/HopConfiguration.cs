using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class HopConfiguration : IEntityTypeConfiguration<Hop>
    {
        public void Configure(EntityTypeBuilder<Hop> builder)
        {
            builder.HasKey(h => h.Id);
            builder
                .HasMany(h => h.RecipeHops)
                .WithOne(rh => rh.Hop)
                .HasForeignKey(rh => rh.HopId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(h => h.Steps)
                .WithOne(s => s.Hop)
                .HasForeignKey(s => s.HopId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
