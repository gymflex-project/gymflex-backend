using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.CreateMuscleGroup
{
    public class CreateMuscleGroupInput(
        string name
    ) : IRequest<MuscleGroupModelOutput>
    { 
        public string Name { get; set; } = name;
    }
}

