using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.UpdateExerciseSubstitution
{
    public interface IUpdateExerciseSubstitution 
        : IRequestHandler<UpdateExerciseSubstitutionInput, ExerciseSubstitutionModelOutput>
    {
    }
}

