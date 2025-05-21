using GymFlex.Application.UseCases.Exercise.Common;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.CreateExercise
{
    public interface ICreateExercise
        : IRequestHandler<CreateExerciseInput, ExerciseModelOutput>
    {
    }

}

