using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.CreateMuscleGroup
{
    public interface ICreateMuscleGroup
        : IRequestHandler<CreateMuscleGroupInput, MuscleGroupModelOutput>
    {
    }

}
