using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.SpecificRegion.UpdateSpecificRegion
{
    public class UpdateSpecificRegion(ISpecificRegionRepository repository, IUnitOfWork unitOfWork) : IUpdateSpecificRegion
    {
        public async Task<SpecificRegionModelOutput> Handle(
            UpdateSpecificRegionInput input, 
            CancellationToken cancellationToken
        )
        {
            var specificRegion = await repository.Get(input.Id, cancellationToken);
            specificRegion.Update(
                input.Name,
                input.MuscleGroupId
            );
            await repository.Update(specificRegion, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return SpecificRegionModelOutput.FromSpecificRegion(specificRegion);
        }
    }
}  
