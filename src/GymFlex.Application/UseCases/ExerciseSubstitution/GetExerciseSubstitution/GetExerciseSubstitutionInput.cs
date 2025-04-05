using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution
{
    public class GetExerciseSubstitutionInput(Guid id) : IRequest<ExerciseSubstitutionModelOutput>
    {
        public Guid Id { get; set; } = id;
    }
}
