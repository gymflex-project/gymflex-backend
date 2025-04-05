using GymFlex.Application.UseCases.Exercise.Common;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    public class GetExerciseInput(Guid id) : IRequest<ExerciseModelOutput>
    {
        public Guid Id { get; set; } = id;
    }
}
