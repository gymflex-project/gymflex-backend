using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Enums;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.UpdateExercise
{
    public class UpdateExerciseInput(
        Guid id,
        string name,
        Guid muscleGroupId,
        Guid specificRegionId,
        DifficultyLevel difficultyLevel,
        string description,
        ExerciseCategory category,
        EquipmentType equipmentType)
        : IRequest<ExerciseModelOutput>
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Guid MuscleGroupId { get; set; } = muscleGroupId;
        public Guid SpecificRegionId { get; set; } = specificRegionId;
        public DifficultyLevel DifficultyLevel { get; set; } = difficultyLevel;
        public string Description { get; set; } = description;
        public ExerciseCategory Category { get; set; } = category;
        public EquipmentType EquipmentType { get; set; } = equipmentType;
    }

}