using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.ListExerciseSubstitutions
{
    interface IListExerciseSubstitutions : IRequestHandler<ListExerciseSubstitutionsInput, ListExerciseSubstitutionsOutput>;
}
