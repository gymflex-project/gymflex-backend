using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup
{
    public class GetMuscleGroup : IGetMuscleGroup
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;
        public GetMuscleGroup(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }
        public async Task<MuscleGroupModelOutput> Handle(
            GetMuscleGroupInput request,
            CancellationToken cancellationToken)
        {
           var muscleGroup = await _muscleGroupRepository.Get(request.Id, cancellationToken);
           return MuscleGroupModelOutput.FromMuscleGroup(muscleGroup);
        }
    }
}
