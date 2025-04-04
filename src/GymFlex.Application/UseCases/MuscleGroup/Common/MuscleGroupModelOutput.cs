using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.MuscleGroup.Common
{
    public class MuscleGroupModelOutput(Guid id, string name)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;

        public static MuscleGroupModelOutput FromMuscleGroup(DomainEntity.MuscleGroup muscleGroup) 
            => new(muscleGroup.Id, muscleGroup.Name);
    }
}
