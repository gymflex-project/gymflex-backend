using GymFlex.Application.Common;
using GymFlex.Application.UseCases.SpecificRegion.Common;

namespace GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions
{
    public class ListSpecificRegionsOutput(int page, int perPage, int total, IReadOnlyList<SpecificRegionModelOutput> items) 
        : PaginatedListOutput<SpecificRegionModelOutput>(page, perPage, total, items);
}
