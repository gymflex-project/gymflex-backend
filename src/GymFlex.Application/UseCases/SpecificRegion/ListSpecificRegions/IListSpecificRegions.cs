using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions
{
    public interface IListSpecificRegions : IRequestHandler<ListSpecificRegionsInput, ListSpecificRegionsOutput>;
}
