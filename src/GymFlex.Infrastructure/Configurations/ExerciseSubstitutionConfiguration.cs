using GymFlex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymFlex.Infrastructure.Configurations
{
    internal class ExerciseSubstitutionConfiguration
        : IEntityTypeConfiguration<ExerciseSubstitution>
    {
        public void Configure(EntityTypeBuilder<ExerciseSubstitution> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Notes)
                .HasMaxLength(255);
        }
    }
}