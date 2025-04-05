using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public class GetSpecificRegion(ISpecificRegionRepository specificRegionRepository) : IGetSpecificRegion
    {
        public async Task<SpecificRegionModelOutput> Handle(
            GetSpecificRegionInput request,
            CancellationToken cancellationToken)
        {
           var specificRegion = await specificRegionRepository.Get(request.Id, cancellationToken);
           return SpecificRegionModelOutput.FromSpecificRegion(specificRegion);
        }
    }
}
