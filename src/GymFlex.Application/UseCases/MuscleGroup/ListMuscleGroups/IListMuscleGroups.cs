using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    interface IGetMuscleGroup : IRequestHandler<GetMuscleGroupInput, GetMuscleGroupOutput>;
}
