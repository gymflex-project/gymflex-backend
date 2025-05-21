using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IMuscleGroupRepository : IGenericRepository<MuscleGroup>, ISearchableRepository<MuscleGroup>
    {
        public Task Insert(MuscleGroup aggregate, CancellationToken cancellationToken);
        public Task Delete(MuscleGroup aggregate, CancellationToken cancellationToken);
        public Task Update(MuscleGroup aggregate, CancellationToken cancellationToken);
    }
}
