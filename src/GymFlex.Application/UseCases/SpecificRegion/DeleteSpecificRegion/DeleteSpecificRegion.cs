using GymFlex.Application.Interfaces;
using GymFlex.Domain.Repositories;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.DeleteSpecificRegion
{
    public class DeleteSpecificRegion(
        ISpecificRegionRepository repository,
        IUnitOfWork unitOfWork)
        : IDeleteSpecificRegion
    {
        public async Task<Unit> Handle(
            DeleteSpecificRegionInput request, 
            CancellationToken cancellationToken
        )
        {
            var specificRegion = await repository.Get(request.Id, cancellationToken);
            await repository.Delete(specificRegion, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return Unit.Value;
        }
    }

}
