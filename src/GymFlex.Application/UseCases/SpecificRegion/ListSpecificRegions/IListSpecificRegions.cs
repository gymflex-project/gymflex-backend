using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions
{
    interface IListSpecificRegions : IRequestHandler<ListSpecificRegionsInput, ListSpecificRegionsOutput>;
}
