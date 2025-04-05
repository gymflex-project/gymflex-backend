using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public interface IGetSpecificRegion : IRequestHandler<GetSpecificRegionInput, SpecificRegionModelOutput>;
}
