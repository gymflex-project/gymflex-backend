using GymFlex.Application.Interfaces;
using DomainEntity = GymFlex.Domain.Entities;
using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.Exercise.CreateExercise
{
    public class CreateExercise(IExerciseRepository repository, IUnitOfWork unitOfWork) : ICreateExercise
    {
        public async Task<ExerciseModelOutput> Handle(CreateExerciseInput request, CancellationToken cancellationToken)
        {
            var exercise = new DomainEntity.Exercise(
                request.Name, 
                request.MuscleGroupId, 
                request.SpecificRegionId,
                request.DifficultyLevel,
                request.Description,
                request.Category,
                request.EquipmentType
                );
            await repository.Insert(exercise, cancellationToken);
            await unitOfWork.Commit(cancellationToken);
            return ExerciseModelOutput.FromExercise(exercise);
        }
    }
}