using System.Linq.Expressions;

namespace Application.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>>? filter);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    }
}
