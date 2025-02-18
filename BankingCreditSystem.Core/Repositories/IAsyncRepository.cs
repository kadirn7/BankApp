using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

public interface IAsyncRepository<T> where T : Entity
{
    // Get Methods
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Get List Methods
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Get Paged List
    Task<(List<T> Items, int Total)> GetPagedListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 10,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Add Methods
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);

    // Update Methods
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> UpdateRangeAsync(List<T> entities, CancellationToken cancellationToken = default);

    // Delete Methods
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> DeleteRangeAsync(List<T> entities, CancellationToken cancellationToken = default);

    // Any Method
    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, 
        CancellationToken cancellationToken = default);

    // Count Method
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, 
        CancellationToken cancellationToken = default);
} 