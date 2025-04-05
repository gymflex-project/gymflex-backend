using GymFlex.Domain.SeedWork.SearchableRepository;

namespace GymFlex.Application.Common
{
    public static class ApplicationDefaults
    {
        public const int DefaultPage = 1;
        public const int DefaultPerPage = 15;
        public const string DefaultSearch = "";
        public const string DefaultSort = "";
        public const SearchOrder DefaultSearchOrder = SearchOrder.Asc;
    }
}
