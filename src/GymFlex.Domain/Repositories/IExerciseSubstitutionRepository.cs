using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IExerciseSubstitutionRepository : IGenericRepository<ExerciseSubstitution>,
        ISearchableRepository<ExerciseSubstitution>
    {
        public Task Insert(ExerciseSubstitution aggregate, CancellationToken cancellationToken);
        public Task Delete(ExerciseSubstitution aggregate, CancellationToken cancellationToken);
        public Task Update(ExerciseSubstitution aggregate, CancellationToken cancellationToken);
    }
}