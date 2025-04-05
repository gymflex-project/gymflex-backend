using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.ListExerciseSubstitutions
{
    public class ListExerciseSubstitutions(IExerciseSubstitutionRepository exerciseSubstitutionRepository)
        : IListExerciseSubstitutions
    {
        public async Task<ListExerciseSubstitutionsOutput> Handle(ListExerciseSubstitutionsInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await exerciseSubstitutionRepository.Search(
                new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.SortDirection
                ),
                cancellationToken
            );

            return new ListExerciseSubstitutionsOutput(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(ExerciseSubstitutionModelOutput.FromExerciseSubstitution)
                .ToList()
            );
        }
    }
}
