using GymFlex.Domain.Enums;
using GymFlex.Domain.SeedWork;
using GymFlex.Domain.Validation;

namespace GymFlex.Domain.Entities
{
    public class ExerciseSubstitution(
        EquivalenceLevel equivalenceLevel, 
        string notes, 
        Guid exerciseId, 
        Guid substituteExerciseId
    ) : AggregateRoot
    {
        public EquivalenceLevel EquivalenceLevel { get; private set; } = equivalenceLevel;
        public string Notes { get; private set; } = notes;
        public Guid ExerciseId { get; private set; } = exerciseId;
        public Exercise? Exercise { get; private set; }
        public Guid SubstituteExerciseId { get; private set; } = substituteExerciseId;
        public Exercise? SubstituteExercise { get; private set; }
        
        public void Update(
            EquivalenceLevel equivalenceLevel, 
            string notes, 
            Guid exerciseId, 
            Guid substituteExerciseId
        )
        {
            EquivalenceLevel = equivalenceLevel;
            Notes = notes;
            ExerciseId = exerciseId;
            SubstituteExerciseId = substituteExerciseId;
            Validate();
        }
        
        private void Validate()
            => DomainValidation.MaxLength(Notes, 255, nameof(Notes));
    }
}
