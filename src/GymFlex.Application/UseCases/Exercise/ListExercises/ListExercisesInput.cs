using GymFlex.Application.Common;
using GymFlex.Domain.SeedWork.SearchableRepository;
using MediatR;

namespace GymFlex.Application.UseCases.Exercise.ListExercises
{
    public class ListExercisesInput(int page = ApplicationDefaults.DefaultPage,
        int perPage = ApplicationDefaults.DefaultPerPage,
        string search = ApplicationDefaults.DefaultSearch,
        string sort = ApplicationDefaults.DefaultSort,
        SearchOrder direction = ApplicationDefaults.DefaultSearchOrder
        ) : PaginatedListInput(page, perPage, search, sort, direction), IRequest<ListExercisesOutput>;
}
