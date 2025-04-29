using GymFlex.Domain.Enums;

namespace GymFlex.Presentation.ApiModels.UpdateApiInput
{
    public class UpdateExerciseApiInput(
        Guid id,
        string name,
        Guid muscleGroupId,
        Guid specificRegionId,
        DifficultyLevel difficultyLevel,
        string description,
        ExerciseCategory exerciseCategory,
        EquipmentType equipmentType)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Guid MuscleGroupId { get; set; } = muscleGroupId;
        public Guid SpecificRegionId { get; set; } = specificRegionId;
        public DifficultyLevel DifficultyLevel { get; set; } = difficultyLevel;
        public string Description { get; set; } = description;
        public ExerciseCategory ExerciseCategory { get; set; } = exerciseCategory;
        public EquipmentType EquipmentType { get; set; } = equipmentType;
    }
}