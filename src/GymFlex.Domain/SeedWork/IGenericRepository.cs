namespace GymFlex.Domain.SeedWork
{
    public interface IGenericRepository<TAggregate> : IRepository
    where TAggregate : AggregateRoot
    {
        public Task<TAggregate> Get(Guid id, CancellationToken cancellationToken);
    }
}
