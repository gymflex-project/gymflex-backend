using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution
{
    public interface IGetExerciseSubstitution : IRequestHandler<GetExerciseSubstitutionInput, ExerciseSubstitutionModelOutput>;
}
