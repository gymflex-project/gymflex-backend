using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public class GetSpecificRegion : IGetSpecificRegion
    {
        private readonly ISpecificRegionRepository _specificRegionRepository;
        public GetSpecificRegion(ISpecificRegionRepository specificRegionRepository)
        {
            _specificRegionRepository = specificRegionRepository;
        }
        public async Task<SpecificRegionModelOutput> Handle(
            GetSpecificRegionInput request,
            CancellationToken cancellationToken)
        {
           var specificRegion = await _specificRegionRepository.Get(request.Id, cancellationToken);
           return SpecificRegionModelOutput.FromSpecificRegion(specificRegion);
        }
    }
}
