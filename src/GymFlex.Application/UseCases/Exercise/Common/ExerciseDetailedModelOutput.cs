using GymFlex.Domain.Enums;
using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.Exercise.Common
{
    public class ExerciseDetailedModelOutput
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public required string Description { get; set; }
        public ExerciseCategory Category { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string? MuscleGroupName { get; set; }
        public string? SpecificRegionName { get; set; }
        
        public static ExerciseDetailedModelOutput? FromExercise(DomainEntity.Exercise exercise) 
            => new ExerciseDetailedModelOutput
            {
                Id = exercise.Id,
                Name = exercise.Name,
                DifficultyLevel = exercise.DifficultyLevel,
                Description = exercise.Description,
                Category = exercise.Category,
                EquipmentType = exercise.EquipmentType,
                MuscleGroupName = exercise.MuscleGroup?.Name,
                SpecificRegionName = exercise.SpecificRegion?.Name
            };
    }
}