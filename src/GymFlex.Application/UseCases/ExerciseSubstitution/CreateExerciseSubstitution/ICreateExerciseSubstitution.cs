using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.CreateExerciseSubstitution
{
    public interface ICreateExerciseSubstitution
        : IRequestHandler<CreateExerciseSubstitutionInput, ExerciseSubstitutionModelOutput>
    {
    }

}
