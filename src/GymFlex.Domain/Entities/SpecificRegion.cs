using GymFlex.Domain.SeedWork;

namespace GymFlex.Domain.Entities
{
    public class SpecificRegion(string name, Guid muscleGroupId) : AggregateRoot
    {
        public string Name { get; private set; } = name;
        public Guid MuscleGroupId { get; private set; } = muscleGroupId;
        public MuscleGroup? MuscleGroup { get; private set; }
        public IReadOnlyCollection<Guid> Exercises => _exercises.AsReadOnly();
        private readonly List<Guid> _exercises = new();

        public void AddExercise(Guid exerciseId)
        {
            _exercises.Add(exerciseId);
        }
    }
}
