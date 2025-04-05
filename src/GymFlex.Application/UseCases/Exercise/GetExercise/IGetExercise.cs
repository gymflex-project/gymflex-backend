using GymFlex.Application.UseCases.Exercise.Common;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    interface IGetExercise : IRequestHandler<GetExerciseInput, ExerciseModelOutput>;
}
