namespace GymFlex.Domain.SeedWork
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; protected set; }
    }
}
