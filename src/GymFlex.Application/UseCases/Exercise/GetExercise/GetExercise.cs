using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    public class GetExercise(IExerciseRepository exerciseRepository) : IGetExercise
    {
        public async Task<ExerciseModelOutput> Handle(
            GetExerciseInput request,
            CancellationToken cancellationToken)
        {
           var exercise = await exerciseRepository.Get(request.Id, cancellationToken);
           return ExerciseModelOutput.FromExercise(exercise);
        }
    }
}
