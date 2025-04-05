using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public class GetSpecificRegionInput(Guid Id) : IRequest<SpecificRegionModelOutput>
    {
        public Guid Id { get; set; } = Id;
    }
}
