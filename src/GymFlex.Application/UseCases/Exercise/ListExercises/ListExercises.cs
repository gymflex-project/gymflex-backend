
using System.ComponentModel.DataAnnotations;
using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.Exercise.ListExercises   
{
    public class ListExercises : IListExercises
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ListExercises(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<ListExercisesOutput> Handle(ListExercisesInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await _exerciseRepository.Search(
                new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.SortDirection
                ),
                cancellationToken
            );

            return new ListExercisesOutput(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                .Select(ExerciseDetailedModelOutput.FromExercise)
                .ToList()
            );
        }
    }
}
