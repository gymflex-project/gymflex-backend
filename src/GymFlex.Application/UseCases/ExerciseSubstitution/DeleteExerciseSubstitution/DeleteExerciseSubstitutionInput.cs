using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.DeleteExerciseSubstitution
{
    public class DeleteExerciseSubstitutionInput(Guid id) : IRequest<Unit>
    {
        public Guid Id { get; private set; } = id;
    }
}

