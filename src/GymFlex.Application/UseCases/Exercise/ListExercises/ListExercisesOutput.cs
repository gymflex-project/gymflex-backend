using GymFlex.Application.Common;
using GymFlex.Application.UseCases.Exercise.Common;

namespace GymFlex.Application.UseCases.Exercise.ListExercises
{
    public class ListExercisesOutput(int page, int perPage, int total, IReadOnlyList<ExerciseModelOutput> items) 
        : PaginatedListOutput<ExerciseModelOutput>(page, perPage, total, items);
}
