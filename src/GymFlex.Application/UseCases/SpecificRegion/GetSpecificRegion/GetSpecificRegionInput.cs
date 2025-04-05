using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public class GetSpecificRegionInput(Guid id) : IRequest<SpecificRegionModelOutput>
    {
        public Guid Id { get; set; } = id;
    }
}
