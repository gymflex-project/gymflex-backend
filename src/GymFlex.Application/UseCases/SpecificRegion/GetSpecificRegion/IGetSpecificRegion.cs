using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    interface IGetSpecificRegion : IRequestHandler<GetSpecificRegionInput, SpecificRegionModelOutput>;
}
