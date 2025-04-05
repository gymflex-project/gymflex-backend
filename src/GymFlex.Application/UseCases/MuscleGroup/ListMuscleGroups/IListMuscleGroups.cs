using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    interface IListMuscleGroups : IRequestHandler<ListMuscleGroupsInput, ListMuscleGroupsOutput>;
}
