using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution
{
    public class GetExerciseSubstitution(IExerciseSubstitutionRepository exerciseSubstitutionRepository)
        : IGetExerciseSubstitution
    {
        public async Task<ExerciseSubstitutionModelOutput> Handle(
            GetExerciseSubstitutionInput request,
            CancellationToken cancellationToken)
        {
           var exerciseSubstitution = await exerciseSubstitutionRepository.Get(request.Id, cancellationToken);
           return ExerciseSubstitutionModelOutput.FromExerciseSubstitution(exerciseSubstitution);
        }
    }
}
