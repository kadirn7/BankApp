using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        
        if (include != null)
            queryable = include(queryable);
        
        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);
        
        var entity = await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        return entity;
    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        
        if (include != null)
            queryable = include(queryable);
        
        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);
        
        if (predicate != null)
            queryable = queryable.Where(predicate);
        
        if (orderBy != null)
            queryable = orderBy(queryable);
        
        var items = await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken);
        return new Paginate<TEntity>(items, items.Count, index, size);
    }

    public async Task<Paginate<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        
        if (include != null)
            queryable = include(queryable);
        
        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);
        
        if (predicate != null)
            queryable = queryable.Where(predicate);

        int total = await queryable.CountAsync(cancellationToken);
        
        if (orderBy != null)
            queryable = orderBy(queryable);
        
        var items = await queryable.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        
        return new Paginate<TEntity>(items, total, pageIndex, pageSize);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
            
        await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
            
        Context.Set<TEntity>().UpdateRange(entities);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default)
    {
        if (permanent)
            Context.Set<TEntity>().Remove(entity);
        else
            entity.DeletedDate = DateTime.UtcNow;
            
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            if (permanent)
                Context.Set<TEntity>().Remove(entity);
            else
                entity.DeletedDate = DateTime.UtcNow;
                
            Context.Set<TEntity>().Update(entity);
        }
            
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }   

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>().AsNoTracking();
        
        if (predicate != null)
            queryable = queryable.Where(predicate);
            
        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>().AsNoTracking();
        
        if (predicate != null)
            queryable = queryable.Where(predicate);
            
        return await queryable.CountAsync(cancellationToken);
    }   
    
} 