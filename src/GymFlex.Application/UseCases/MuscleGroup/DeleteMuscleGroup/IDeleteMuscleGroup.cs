using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.DeleteMuscleGroup
{
    public interface IDeleteMuscleGroup
        : IRequestHandler<DeleteMuscleGroupInput, Unit>
    { }
}
