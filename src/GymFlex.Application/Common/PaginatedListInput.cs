using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Application.Common
{
    public abstract class PaginatedListInput(int page, int perPage, string sort, string search, SearchOrder sortDirection)
    {
        public int Page { get; set; } = page;
        public int PerPage { get; set; } = perPage;
        public string Sort { get; set; } = sort;
        public string Search { get; set; } = search;
        public SearchOrder SortDirection { get; set; } = sortDirection;

        public SearchInput ToSearchInput() 
            => new(Page, PerPage, Search, Sort, SortDirection);
    }
}
