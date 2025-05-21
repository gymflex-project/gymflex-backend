using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Domain.Repositories;
using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.MuscleGroup.CreateMuscleGroup
{
    public class CreateMuscleGroup(IMuscleGroupRepository repository, IUnitOfWork unitOfWork) : ICreateMuscleGroup
    {
        public async Task<MuscleGroupModelOutput> Handle(CreateMuscleGroupInput request, CancellationToken cancellationToken)
        {
            var muscleGroup = new DomainEntity.MuscleGroup(request.Name);
            await repository.Insert(muscleGroup, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return MuscleGroupModelOutput.FromMuscleGroup(muscleGroup);
        }
    }
}
