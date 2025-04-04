using GymFlex.Application.UseCases.MuscleGroup.Common;
using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup
{
    interface IGetMuscleGroup : IRequestHandler<GetMuscleGroupInput, MuscleGroupModelOutput>;
}
