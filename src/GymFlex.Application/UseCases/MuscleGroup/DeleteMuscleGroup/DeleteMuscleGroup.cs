using GymFlex.Application.Interfaces;
using GymFlex.Domain.Repositories;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.DeleteMuscleGroup
{
    public class DeleteMuscleGroup(
        IMuscleGroupRepository repository,
        IUnitOfWork unitOfWork)
        : IDeleteMuscleGroup
    {
        public async Task<Unit> Handle(
            DeleteMuscleGroupInput request, 
            CancellationToken cancellationToken
        )
        {
            var muscleGroup = await repository.Get(request.Id, cancellationToken);
            await repository.Delete(muscleGroup, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return Unit.Value;
        }
    }

}
