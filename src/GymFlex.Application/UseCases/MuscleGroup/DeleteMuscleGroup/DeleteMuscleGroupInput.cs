using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.DeleteMuscleGroup
{
    public class DeleteMuscleGroupInput(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}

