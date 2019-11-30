using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class BrewConfiguration : IEntityTypeConfiguration<Brew>
    {
        public void Configure(EntityTypeBuilder<Brew> builder)
        {
            builder.HasIndex(b => b.Id);
        }
    }
}
