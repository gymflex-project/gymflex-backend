using GymFlex.Application.Interfaces;
using GymFlex.Infrastructure.Data.Context;

namespace GymFlex.Infrastructure.Data
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public Task Commit(CancellationToken cancellationToken)
            => context.SaveChangesAsync(cancellationToken);

        public Task Rollback(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
