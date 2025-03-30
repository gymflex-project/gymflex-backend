using GymFlex.Domain.SeedWork;

namespace GymFlex.Domain.Entities
{
    public class MuscleGroup(string name) : AggregateRoot
    {
        public string Name { get; private set; } = name;
        public IReadOnlyCollection<Guid> Exercises => _exercises.AsReadOnly();
        private readonly List<Guid> _exercises = new();

        public void AddExercise(Guid exerciseId)
        {
            _exercises.Add(exerciseId);
        }
    }
}
