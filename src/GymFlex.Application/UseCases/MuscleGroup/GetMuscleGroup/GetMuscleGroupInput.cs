using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup
{
    public class GetMuscleGroupInput(Guid Id) : IRequest<MuscleGroupModelOutput>
    {
        public Guid Id { get; set; } = Id;
    }
}
