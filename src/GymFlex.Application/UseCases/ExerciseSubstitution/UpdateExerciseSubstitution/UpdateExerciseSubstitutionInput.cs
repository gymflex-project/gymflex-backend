using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Domain.Enums;
using MediatR;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.UpdateExerciseSubstitution
{
    public class UpdateExerciseSubstitutionInput(
        Guid id,
        EquivalenceLevel equivalenceLevel, 
        string notes, 
        Guid exerciseId, 
        Guid substituteExerciseId
    ) : IRequest<ExerciseSubstitutionModelOutput>
    {
        public Guid Id { get; set; } = id;
        public EquivalenceLevel EquivalenceLevel { get; private set; } = equivalenceLevel;
        public string Notes { get; private set; } = notes;
        public Guid ExerciseId { get; private set; } = exerciseId;
        public Guid SubstituteExerciseId { get; private set; } = substituteExerciseId;
    }
}