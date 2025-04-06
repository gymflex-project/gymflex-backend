using GymFlex.Application.Exceptions;
using GymFlex.Domain.Entities;
using GymFlex.Domain.Repositories;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymFlex.Infrastructure.Repositories
{
    public class SpecificRegionRepository(ApplicationDbContext context) : ISpecificRegionRepository
    {
        private readonly ApplicationDbContext _context = context;
        private DbSet<SpecificRegion> _specificRegions => _context.Set<SpecificRegion>();
        public async Task<SpecificRegion> Get(Guid id, CancellationToken cancellationToken)
        {
            var exercise = await _specificRegions.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken
            );
            NotFoundException.ThrowIfNull(exercise, $"Specific Region '{id}' not found.");
            return exercise!;
        }
        
        public async Task<SearchOutput<SpecificRegion>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            var query = _specificRegions.AsNoTracking();

            query = AddOrderToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                string searchLower;
                searchLower = input.Search.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(searchLower));
            }

            var total = await query.CountAsync(cancellationToken);
            var items = await query.Skip(toSkip)
                                   .Take(input.PerPage)
                                   .ToListAsync(cancellationToken);

            return new(input.Page, input.PerPage, total, items);
        }

        private static IQueryable<SpecificRegion> AddOrderToQuery(
            IQueryable<SpecificRegion> query,
            string orderProperty,
            SearchOrder order)
        {
            var orderedQuery = (orderProperty.ToLower(), order) switch
            {
                ("name", SearchOrder.Asc) => query.OrderBy(x => x.Name).ThenBy(x => x.Id),
                ("name", SearchOrder.Desc) => query.OrderByDescending(x => x.Name).ThenByDescending(x => x.Id),
                ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),  
                ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
                ("createdat", SearchOrder.Asc) => query.OrderBy(x => x.CreatedAt),
                ("createdat", SearchOrder.Desc) => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderBy(x => x.Name).ThenBy(x => x.Id)
            };
            return orderedQuery;
        }
    }   
}