using MediatR;

namespace GymFlex.Application.UseCases.Exercise.ListExercises
{
    interface IListExercises : IRequestHandler<ListExercisesInput,ListExercisesOutput>;
}
