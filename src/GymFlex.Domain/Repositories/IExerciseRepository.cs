using GymFlex.Domain.Entities;
using FC.Codeflix.Catalog.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface IExerciseRepository : IGenericRepository<Exercise>, ISearchableRepository<Exercise>
    {
    }
}
