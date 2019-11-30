using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class FermentableConfiguration : IEntityTypeConfiguration<Fermentable>
    {
        public void Configure(EntityTypeBuilder<Fermentable> builder)
        {
            builder.HasIndex(f => f.Id);
        }
    }
}
