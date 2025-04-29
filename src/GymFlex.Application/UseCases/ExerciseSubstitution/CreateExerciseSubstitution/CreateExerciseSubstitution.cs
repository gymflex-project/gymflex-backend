using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Repositories;
using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.CreateExerciseSubstitution
{
    public class CreateExerciseSubstitution(IExerciseSubstitutionRepository repository, IUnitOfWork unitOfWork) : ICreateExerciseSubstitution
    {
        public async Task<ExerciseSubstitutionModelOutput> Handle(CreateExerciseSubstitutionInput request, CancellationToken cancellationToken)
        {
            var exerciseSubstitution = new DomainEntity.ExerciseSubstitution(
                request.EquivalenceLevel,
                request.Notes,
                request.ExerciseId,
                request.SubstituteExerciseId
            );
            await repository.Insert(exerciseSubstitution, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return ExerciseSubstitutionModelOutput.FromExerciseSubstitution(exerciseSubstitution);
        }
    }
}
