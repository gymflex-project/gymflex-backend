using Microsoft.EntityFrameworkCore;
using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;

namespace GymFlex.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseSubstitution> ExerciseSubstitutions { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<SpecificRegion> SpecificRegions { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            // Obtém todas as entidades que implementam AuditableEntity
            // e que estão sendo adicionadas ou modificadas no contexto.
            var auditableEntries = ChangeTracker.Entries<AuditableEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in auditableEntries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
