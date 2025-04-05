using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    public class ListMuscleGroups : IListMuscleGroups
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;
        public ListMuscleGroups(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }
        public async Task<ListMuscleGroupsOutput> Handle(ListMuscleGroupsInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await _muscleGroupRepository.Search(
                new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.SortDirection
                ),
                cancellationToken
            );

            return new ListMuscleGroupsOutput(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(MuscleGroupModelOutput.FromMuscleGroup)
                .ToList()
            );
        }
    }
}
