using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Enums;
using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.Common
{
    public class ExerciseSubstitutionModelOutput(
        Guid id,
        string notes,
        EquivalenceLevel equivalenceLevel,
        ExerciseDetailedModelOutput? substituteExercise = null)
    {
        public Guid Id { get; set; } = id;
        public string Notes { get; set; } = notes;
        public EquivalenceLevel EquivalenceLevel { get; set; } = equivalenceLevel;
        public ExerciseDetailedModelOutput? SubstituteExercise { get; set; } = substituteExercise;

        public static ExerciseSubstitutionModelOutput FromExerciseSubstitution(DomainEntity.ExerciseSubstitution exerciseSubstitution) 
            => new(exerciseSubstitution.Id, exerciseSubstitution.Notes, exerciseSubstitution.EquivalenceLevel)
            {
                SubstituteExercise = exerciseSubstitution.SubstituteExercise is not null 
                    ? ExerciseDetailedModelOutput.FromExercise(exerciseSubstitution.SubstituteExercise) 
                    : null
            };
    }
}
