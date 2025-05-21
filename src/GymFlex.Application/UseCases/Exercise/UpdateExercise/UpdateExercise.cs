using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.Exercise.UpdateExercise
{
    public class UpdateExercise(IExerciseRepository repository, IUnitOfWork unitOfWork) : IUpdateExercise
    {
        public async Task<ExerciseModelOutput> Handle(
            UpdateExerciseInput input, 
            CancellationToken cancellationToken
        )
        {
            var exercise = await repository.Get(input.Id, cancellationToken);
            exercise.Update(
                input.Name, 
                input.MuscleGroupId, 
                input.SpecificRegionId, 
                input.DifficultyLevel,
                input.Description, 
                input.Category, 
                input.EquipmentType);
            await repository.Update(exercise, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return ExerciseModelOutput.FromExercise(exercise);
        }
    }
}
