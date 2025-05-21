using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.DeleteSpecificRegion
{
    public interface IDeleteSpecificRegion
        : IRequestHandler<DeleteSpecificRegionInput, Unit>
    { }
}
