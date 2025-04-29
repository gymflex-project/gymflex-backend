using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Domain.Repositories;
using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.SpecificRegion.CreateSpecificRegion
{
    public class CreateSpecificRegion(ISpecificRegionRepository repository, IUnitOfWork unitOfWork) : ICreateSpecificRegion
    {
        public async Task<SpecificRegionModelOutput> Handle(CreateSpecificRegionInput request, CancellationToken cancellationToken)
        {
            var specificRegion = new DomainEntity.SpecificRegion(
                request.Name,
                request.MuscleGroupId
            );
            await repository.Insert(specificRegion, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return SpecificRegionModelOutput.FromSpecificRegion(specificRegion);
        }
    }
}
