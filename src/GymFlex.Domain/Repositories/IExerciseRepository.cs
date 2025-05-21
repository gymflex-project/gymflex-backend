using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IExerciseRepository : IGenericRepository<Exercise>, ISearchableRepository<Exercise>
    {
        public Task Insert(Exercise aggregate, CancellationToken cancellationToken);
        public Task Delete(Exercise aggregate, CancellationToken cancellationToken);
        public Task Update(Exercise aggregate, CancellationToken cancellationToken);
    }
}
