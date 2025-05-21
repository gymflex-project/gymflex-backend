using GymFlex.Application.Exceptions;
using GymFlex.Domain.Entities;
using GymFlex.Domain.Repositories;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymFlex.Infrastructure.Repositories
{
    public class ExerciseSubstitutionRepository(ApplicationDbContext context) : IExerciseSubstitutionRepository
    {
        private readonly ApplicationDbContext _context = context;
        private DbSet<ExerciseSubstitution> _exerciseSubstitutions => _context.Set<ExerciseSubstitution>();

        public async Task<ExerciseSubstitution> Get(Guid id, CancellationToken cancellationToken)
        {
            var exerciseSubstitution = await _exerciseSubstitutions.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken
            );
            NotFoundException.ThrowIfNull(exerciseSubstitution, $"ExerciseSubstitution '{id}' not found.");
            return exerciseSubstitution!;
        }

        public async Task Insert(ExerciseSubstitution aggregate, CancellationToken cancellationToken) 
            => await _exerciseSubstitutions.AddAsync(aggregate, cancellationToken);
        
        public Task Delete(ExerciseSubstitution aggregate, CancellationToken _)
            => Task.FromResult(_exerciseSubstitutions.Remove(aggregate));
        
        public Task Update(ExerciseSubstitution aggregate, CancellationToken _) 
            => Task.FromResult(_exerciseSubstitutions.Update(aggregate));
        
        public async Task<SearchOutput<ExerciseSubstitution>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            IQueryable<ExerciseSubstitution> query = _exerciseSubstitutions.AsNoTracking()
                .Include(e => e.SubstituteExercise)
                .Include(e => e.SubstituteExercise.SpecificRegion)
                .Include(e => e.SubstituteExercise.MuscleGroup);

            query = AddOrderToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrWhiteSpace(input.Search))
                query = query.Where(x => x.ExerciseId.ToString() == input.Search);

            var total = await query.CountAsync(cancellationToken);
            var items = await query.Skip(toSkip)
                                   .Take(input.PerPage)
                                   .ToListAsync(cancellationToken);

            return new(input.Page, input.PerPage, total, items);
        }

        private static IQueryable<ExerciseSubstitution> AddOrderToQuery(
            IQueryable<ExerciseSubstitution> query,
            string orderProperty,
            SearchOrder order)
        {
            var orderedQuery = (orderProperty.ToLower(), order) switch
            {
                ("exerciseId", SearchOrder.Asc) => query.OrderBy(x => x.ExerciseId).ThenBy(x => x.Id),
                ("exerciseId", SearchOrder.Desc) => query.OrderByDescending(x => x.ExerciseId).ThenByDescending(x => x.Id),
                ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),  
                ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
                ("createdat", SearchOrder.Asc) => query.OrderBy(x => x.CreatedAt),
                ("createdat", SearchOrder.Desc) => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderBy(x => x.ExerciseId).ThenBy(x => x.Id)
            };
            return orderedQuery;
        }
    }
}