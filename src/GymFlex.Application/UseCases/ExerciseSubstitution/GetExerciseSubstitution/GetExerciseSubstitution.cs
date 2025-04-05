using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution
{
    public class GetExerciseSubstitution : IGetExerciseSubstitution
    {
        private readonly IExerciseSubstitutionRepository _exerciseSubstitutionRepository;
        public GetExerciseSubstitution(IExerciseSubstitutionRepository exerciseSubstitutionRepository)
        {
            _exerciseSubstitutionRepository = exerciseSubstitutionRepository;
        }
        public async Task<ExerciseSubstitutionModelOutput> Handle(
            GetExerciseSubstitutionInput request,
            CancellationToken cancellationToken)
        {
           var exerciseSubstitution = await _exerciseSubstitutionRepository.Get(request.Id, cancellationToken);
           return ExerciseSubstitutionModelOutput.FromExerciseSubstitution(exerciseSubstitution);
        }
    }
}
