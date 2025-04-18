using Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DbSet<T> _db;
        public readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _db;
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>>? filter)
        {
            if (filter != null) return await _db.Where(filter).ToListAsync();
            return await _db.ToListAsync();
        }

        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _db;
            return await query.AnyAsync(filter);
        }
    }
}
