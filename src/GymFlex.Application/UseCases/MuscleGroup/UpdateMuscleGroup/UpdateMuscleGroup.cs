using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.MuscleGroup.UpdateMuscleGroup
{
    public class UpdateMuscleGroup(IMuscleGroupRepository repository, IUnitOfWork unitOfWork) : IUpdateMuscleGroup
    {
        public async Task<MuscleGroupModelOutput> Handle(
            UpdateMuscleGroupInput input, 
            CancellationToken cancellationToken
        )
        {
            var muscleGroup = await repository.Get(input.Id, cancellationToken);
            muscleGroup.Update(
                input.Name
            );
            await repository.Update(muscleGroup, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return MuscleGroupModelOutput.FromMuscleGroup(muscleGroup);
        }
    }
}  
