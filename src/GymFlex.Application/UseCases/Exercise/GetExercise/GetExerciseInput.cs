using GymFlex.Application.UseCases.Exercise.Common;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    public class GetExerciseInput(Guid Id) : IRequest<ExerciseModelOutput>
    {
        public Guid Id { get; set; } = Id;
    }
}
