using MediatR;

namespace GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups
{
    public interface IListMuscleGroups : IRequestHandler<ListMuscleGroupsInput, ListMuscleGroupsOutput>;
}
