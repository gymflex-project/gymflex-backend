using GymFlex.Application.Exceptions;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Domain.Entities;
using GymFlex.Domain.Repositories;
using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymFlex.Infrastructure.Repositories
{
    public class ExerciseRepository(ApplicationDbContext context) : IExerciseRepository
    {
        private readonly ApplicationDbContext _context = context;
        private DbSet<Exercise> _exercises => _context.Set<Exercise>();

        public async Task<Exercise> Get(Guid id, CancellationToken cancellationToken)
        {
            var exercise = await _exercises.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken
            );
            NotFoundException.ThrowIfNull(exercise, $"Exercise '{id}' not found.");
            return exercise!;
        }

        public async Task<SearchOutput<Exercise>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            IQueryable<Exercise> query = _exercises.AsNoTracking()
                .Include(e => e.MuscleGroup)
                .Include(e => e.SpecificRegion);


            query = AddOrderToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                string searchLower;
                searchLower = input.Search.ToLower();
                query = query.Where(x =>
                    x.Name.ToLower().Contains(searchLower) ||
                    (x.MuscleGroup != null && x.MuscleGroup.Name.ToLower().Contains(searchLower)) ||
                    (x.SpecificRegion != null && x.SpecificRegion.Name.ToLower().Contains(searchLower))
                );

            }

            var total = await query.CountAsync(cancellationToken);
            var items = await query.Skip(toSkip)
                                   .Take(input.PerPage)
                                   .ToListAsync(cancellationToken);

            return new(input.Page, input.PerPage, total, items);
        }

        private static IQueryable<Exercise> AddOrderToQuery(
            IQueryable<Exercise> query,
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
