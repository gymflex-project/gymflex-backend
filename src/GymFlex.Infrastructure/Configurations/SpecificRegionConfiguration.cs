using GymFlex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymFlex.Infrastructure.Configurations
{
    internal class SpecificRegionConfiguration
        : IEntityTypeConfiguration<SpecificRegion>
    {
        public void Configure(EntityTypeBuilder<SpecificRegion> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Name)
                .HasMaxLength(255);
        }
    }
}