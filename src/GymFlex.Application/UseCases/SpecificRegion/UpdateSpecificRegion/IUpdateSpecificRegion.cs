using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.UpdateSpecificRegion
{
    public interface IUpdateSpecificRegion 
        : IRequestHandler<UpdateSpecificRegionInput, SpecificRegionModelOutput>
    {
    }
}

