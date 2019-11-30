using System;
using System.Collections.Generic;
using System.Text;
using Frank.Brewery.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frank.Brewery.DataContexts.EntityConfigurations
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasKey(s => s.Id);
            builder
                .HasOne(s => s.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(s => s.Hop)
                .WithMany(h => h.Steps)
                .HasForeignKey(s => s.HopId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
