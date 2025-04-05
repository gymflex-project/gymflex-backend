using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions
{
    public class ListSpecificRegions(ISpecificRegionRepository specificRegionRepository) : IListSpecificRegions
    {
        public async Task<ListSpecificRegionsOutput> Handle(ListSpecificRegionsInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await specificRegionRepository.Search(
                new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.SortDirection
                ),
                cancellationToken
            );

            return new ListSpecificRegionsOutput(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(SpecificRegionModelOutput.FromSpecificRegion)
                .ToList()
            );
        }
    }
}
