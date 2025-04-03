using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IExerciseSubstitutionRepository : IGenericRepository<ExerciseSubstitution>, ISearchableRepository<ExerciseSubstitution>;
}