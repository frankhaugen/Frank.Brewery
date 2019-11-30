using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class YeastConfiguration : IEntityTypeConfiguration<Yeast>
    {
        public void Configure(EntityTypeBuilder<Yeast> builder)
        {
            builder.HasIndex(y => y.Id);
        }
    }
}
