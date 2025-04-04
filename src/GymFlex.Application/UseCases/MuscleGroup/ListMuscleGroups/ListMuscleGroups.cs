
using System.ComponentModel.DataAnnotations;
using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    public class GetMuscleGroup : IGetMuscleGroup
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;
        public GetMuscleGroup(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }
        public async Task<GetMuscleGroupOutput> Handle(GetMuscleGroupInput request, CancellationToken cancellationToken)
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

            return new GetMuscleGroupOutput(
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
