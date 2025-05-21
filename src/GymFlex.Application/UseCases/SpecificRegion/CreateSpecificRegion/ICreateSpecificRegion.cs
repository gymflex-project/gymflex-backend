using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.CreateSpecificRegion
{
    public interface ICreateSpecificRegion
        : IRequestHandler<CreateSpecificRegionInput, SpecificRegionModelOutput>
    {
    }

}
