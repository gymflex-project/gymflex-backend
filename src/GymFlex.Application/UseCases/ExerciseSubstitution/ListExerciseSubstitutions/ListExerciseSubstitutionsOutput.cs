using GymFlex.Application.Common;
using GymFlex.Application.UseCases.ExerciseSubstitution.Common;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.ListExerciseSubstitutions
{
    public class ListExerciseSubstitutionsOutput(int page, int perPage, int total, IReadOnlyList<ExerciseSubstitutionModelOutput> items) 
        : PaginatedListOutput<ExerciseSubstitutionModelOutput>(page, perPage, total, items);
}
