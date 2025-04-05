using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup
{
    public class GetMuscleGroup(IMuscleGroupRepository muscleGroupRepository) : IGetMuscleGroup
    {
        public async Task<MuscleGroupModelOutput> Handle(
            GetMuscleGroupInput request,
            CancellationToken cancellationToken)
        {
           var muscleGroup = await muscleGroupRepository.Get(request.Id, cancellationToken);
           return MuscleGroupModelOutput.FromMuscleGroup(muscleGroup);
        }
    }
}
