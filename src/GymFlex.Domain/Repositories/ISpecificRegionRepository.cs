using GymFlex.Domain.Entities;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Domain.Repositories
{
    public interface ISpecificRegionRepository : IGenericRepository<SpecificRegion>,
        ISearchableRepository<SpecificRegion>
    {
        public Task Insert(SpecificRegion aggregate, CancellationToken cancellationToken);
        public Task Delete(SpecificRegion aggregate, CancellationToken cancellationToken);
        public Task Update(SpecificRegion aggregate, CancellationToken cancellationToken);
    }
}