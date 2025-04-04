using GymFlex.Application.Common;
using GymFlex.Application.UseCases.MuscleGroup.Common;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    public class GetMuscleGroupOutput(int page, int perPage, int total, IReadOnlyList<MuscleGroupModelOutput> items) 
        : PaginatedListOutput<MuscleGroupModelOutput>(page, perPage, total, items);
}
