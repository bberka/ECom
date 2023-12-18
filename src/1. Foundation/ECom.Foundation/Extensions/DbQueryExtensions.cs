namespace ECom.Foundation.Extensions;

public static class DbQueryExtensions
{
  public static Task<IQueryable<TEntity>> PagingAsync<TEntity>(this DbSet<TEntity> dbSet, int skip, int take)
    where TEntity : class, new() {
    return Task.FromResult(dbSet.AsQueryable().Skip(skip).Take(take));
  }

  public static IQueryable<TEntity> Paging<TEntity>(this DbSet<TEntity> dbSet, int skip, int take)
    where TEntity : class, new() {
    return dbSet.AsQueryable().Skip(skip).Take(take);
  }

  public static IQueryable<TEntity> Paging<TEntity>(this IQueryable<TEntity> queryable, int skip, int take)
    where TEntity : class, new() {
    return queryable.Skip(skip).Take(take);
  }

  public static Task<IQueryable<TEntity>> PagingAsync<TEntity>(this IQueryable<TEntity> queryable, int skip, int take)
    where TEntity : class, new() {
    return Task.FromResult(queryable.Skip(skip).Take(take));
  }
}