using GymFlex.Application.UseCases.Exercise.Common;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.UpdateExercise
{
    public interface IUpdateExercise 
        : IRequestHandler<UpdateExerciseInput, ExerciseModelOutput>
    {
    }
}

