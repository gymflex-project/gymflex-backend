using GymFlex.Application.Exceptions;
using GymFlex.Domain.Entities;
using GymFlex.Domain.Repositories;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymFlex.Infrastructure.Repositories
{
    public class MuscleGroupRepository(ApplicationDbContext context) : IMuscleGroupRepository
    {
        private readonly ApplicationDbContext _context = context;
        private DbSet<MuscleGroup> _muscleGroups => _context.Set<MuscleGroup>();
        public async Task<MuscleGroup> Get(Guid id, CancellationToken cancellationToken)
        {
            var exercise = await _muscleGroups.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken
            );
            NotFoundException.ThrowIfNull(exercise, $"Muscle Group '{id}' not found.");
            return exercise!;
        }
        
        public async Task<SearchOutput<MuscleGroup>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            var query = _muscleGroups.AsNoTracking();

            query = AddOrderToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrWhiteSpace(input.Search))
                query = query.Where(x => x.Name.Contains(input.Search));

            var total = await query.CountAsync(cancellationToken);
            var items = await query.Skip(toSkip)
                                   .Take(input.PerPage)
                                   .ToListAsync(cancellationToken);

            return new(input.Page, input.PerPage, total, items);
        }

        private static IQueryable<MuscleGroup> AddOrderToQuery(
            IQueryable<MuscleGroup> query,
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