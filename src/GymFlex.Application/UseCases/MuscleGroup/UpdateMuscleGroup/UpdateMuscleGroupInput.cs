using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.UpdateMuscleGroup
{
    public class UpdateMuscleGroupInput(
        Guid id,
        string name
    ) : IRequest<MuscleGroupModelOutput>
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}