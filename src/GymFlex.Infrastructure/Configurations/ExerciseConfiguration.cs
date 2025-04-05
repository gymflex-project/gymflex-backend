using GymFlex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymFlex.Infrastructure.Configurations
{
    internal class ExerciseConfiguration
        : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Name)
                .HasMaxLength(255);
            builder.Property(category => category.Description)
                .HasMaxLength(10_000);
        }
    }
}

