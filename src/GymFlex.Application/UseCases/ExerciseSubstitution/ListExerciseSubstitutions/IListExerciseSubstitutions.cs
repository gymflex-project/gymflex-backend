using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.ListExerciseSubstitutions
{
   public interface IListExerciseSubstitutions : IRequestHandler<ListExerciseSubstitutionsInput, ListExerciseSubstitutionsOutput>;
}
