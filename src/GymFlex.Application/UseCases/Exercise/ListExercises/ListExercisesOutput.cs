using GymFlex.Application.Common;
using GymFlex.Application.UseCases.Exercise.Common;

namespace GymFlex.Application.UseCases.Exercise.ListExercises
{
    public class ListExercisesOutput(int page, int perPage, int total, IReadOnlyList<ExerciseDetailedModelOutput> items) 
        : PaginatedListOutput<ExerciseDetailedModelOutput>(page, perPage, total, items);
}
