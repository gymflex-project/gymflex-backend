using GymFlex.Application.Interfaces;
using GymFlex.Domain.Repositories;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.DeleteExerciseSubstitution
{
    public class DeleteExerciseSubstitution(
        IExerciseSubstitutionRepository repository,
        IUnitOfWork unitOfWork)
        : IDeleteExerciseSubstitution
    {
        public async Task<Unit> Handle(
            DeleteExerciseSubstitutionInput request, 
            CancellationToken cancellationToken
        )
        {
            var exerciseSubstitution = await repository.Get(request.Id, cancellationToken);
            await repository.Delete(exerciseSubstitution, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return Unit.Value;
        }
    }

}
