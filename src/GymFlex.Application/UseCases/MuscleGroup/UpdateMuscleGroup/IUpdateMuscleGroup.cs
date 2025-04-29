using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.UpdateMuscleGroup
{
    public interface IUpdateMuscleGroup 
        : IRequestHandler<UpdateMuscleGroupInput, MuscleGroupModelOutput>
    {
    }
}

