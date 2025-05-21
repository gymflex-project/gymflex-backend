using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.UpdateExerciseSubstitution
{
    public class UpdateExerciseSubstitution(IExerciseSubstitutionRepository repository, IUnitOfWork unitOfWork) : IUpdateExerciseSubstitution
    {
        public async Task<ExerciseSubstitutionModelOutput> Handle(
            UpdateExerciseSubstitutionInput input, 
            CancellationToken cancellationToken
        )
        {
            var exerciseSubstitution = await repository.Get(input.Id, cancellationToken);
            exerciseSubstitution.Update(
                input.EquivalenceLevel,
                input.Notes,
                input.ExerciseId,
                input.SubstituteExerciseId
            );
            await repository.Update(exerciseSubstitution, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return ExerciseSubstitutionModelOutput.FromExerciseSubstitution(exerciseSubstitution);
        }
    }
}  
