using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.Common
{
    public class ExerciseSubstitutionModelOutput(Guid id, string name)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;

        public static ExerciseSubstitutionModelOutput FromExerciseSubstitution(DomainEntity.ExerciseSubstitution exerciseSubstitution) 
            => new(exerciseSubstitution.Id, exerciseSubstitution.Notes);
    }
}
