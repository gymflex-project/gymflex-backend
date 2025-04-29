using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Enums;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.CreateExercise
{
    public class CreateExerciseInput(
        string name, 
        Guid muscleGroupId, 
        Guid specificRegionId, 
        DifficultyLevel difficultyLevel, 
        string description,
        ExerciseCategory category, 
        EquipmentType equipmentType
        ) : IRequest<ExerciseModelOutput>
    {
        public string Name { get; private set; } = name;
        public Guid MuscleGroupId { get; private set; } = muscleGroupId;
        public Guid SpecificRegionId { get; private set; } = specificRegionId;
        public DifficultyLevel DifficultyLevel { get; private set; } = difficultyLevel;
        public string Description { get; private set; } = description;
        public ExerciseCategory Category { get; private set; } = category;
        public EquipmentType EquipmentType { get; private set; } = equipmentType;
    }
}
