using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.DeleteExerciseSubstitution
{
    public interface IDeleteExerciseSubstitution
        : IRequestHandler<DeleteExerciseSubstitutionInput, Unit>
    { }
}
