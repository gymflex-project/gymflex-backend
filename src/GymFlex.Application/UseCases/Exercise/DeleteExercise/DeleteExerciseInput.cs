using MediatR;

namespace GymFlex.Application.UseCases.Exercise.DeleteExercise
{
    public class DeleteExerciseInput(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}

