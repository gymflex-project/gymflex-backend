using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.DeleteSpecificRegion
{
    public class DeleteSpecificRegionInput(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}

