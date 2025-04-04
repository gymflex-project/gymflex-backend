using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.Exercise.Common
{
    public class ExerciseModelOutput(Guid id, string name)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;

        public static ExerciseModelOutput FromExercise(DomainEntity.Exercise exercise) 
            => new(exercise.Id, exercise.Name);
    }
}
