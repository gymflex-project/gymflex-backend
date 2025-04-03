using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IMuscleGroupRepository : IGenericRepository<MuscleGroup>, ISearchableRepository<MuscleGroup>;
}
