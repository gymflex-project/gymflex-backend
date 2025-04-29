using GymFlex.Application.Interfaces;
using GymFlex.Domain.Repositories;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.DeleteExercise
{
    public class DeleteExercise(
        IExerciseRepository repository,
        IUnitOfWork unitOfWork)
        : IDeleteExercise
    {
        public async Task<Unit> Handle(
            DeleteExerciseInput request, 
            CancellationToken cancellationToken
        )
        {
            var exercise = await repository.Get(request.Id, cancellationToken);
            await repository.Delete(exercise, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return Unit.Value;
        }
    }

}
