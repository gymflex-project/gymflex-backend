using GymFlex.Domain.Enums;

namespace GymFlex.Presentation.ApiModels.UpdateApiInput
{
    public class UpdateExerciseSubstitutionApiInput(
        Guid id,
        EquivalenceLevel equivalenceLevel, 
        string notes, 
        Guid exerciseId, 
        Guid substituteExerciseId)
    {
        public Guid Id { get; set; } = id;
        public EquivalenceLevel EquivalenceLevel { get; set; } = equivalenceLevel;
        public string Notes { get; set; } = notes;
        public Guid ExerciseId { get; set; } = exerciseId;
        public Guid SubstituteExerciseId { get; set; } = substituteExerciseId;
    }
}