using MediatR;

namespace GymFlex.Application.UseCases.Exercise.DeleteExercise
{
    public interface IDeleteExercise
        : IRequestHandler<DeleteExerciseInput, Unit>
    { }
}

