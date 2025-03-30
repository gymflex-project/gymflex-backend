using GymFlex.Domain.Enums;
using GymFlex.Domain.SeedWork;

namespace GymFlex.Domain.Entities
{
    public class Exercise(
        string name,
        Guid muscleGroupId,
        Guid specificRegionId,
        DifficultyLevel difficultyLevel,
        string description,
        ExerciseCategory category,
        EquipmentType equipmentType
    ) : AggregateRoot()
    {
        public string Name { get; private set; } = name;
        public DifficultyLevel DifficultyLevel { get; private set; } = difficultyLevel;
        public string Description { get; private set; } = description;
        public ExerciseCategory Category { get; private set; } = category;
        public EquipmentType EquipmentType { get; private set; } = equipmentType;
        public Guid MuscleGroupId { get; private set; } = muscleGroupId;
        public MuscleGroup? MuscleGroup { get; private set; }
        public Guid SpecificRegionId { get; private set; } = specificRegionId;
        public SpecificRegion? SpecificRegion { get; private set; }
    }
}
