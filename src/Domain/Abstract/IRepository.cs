using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECom.Domain.Abstract;

public interface IRepository<TEntity> : IRepositoryAsync<TEntity>, IRepositorySync<TEntity>
   where TEntity : class, IEntity, new()
{
}
public interface IRepositoryAsync<TEntity>
  where TEntity : class, IEntity, new()
{
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryable<TEntity>> GetAsync<TKey>(
      Expression<Func<TEntity, bool>>? predicateExpression = null,
      Expression<Func<TEntity, TKey>>? orderByExpression = null,
      bool isDescending = false,
      int? skip = null,
      int? take = null,
      params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> FindAsync(params object[] keys);

    Task<TEntity?> SingleOrDefaultAsync();
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> FirstOrDefaultAsync();
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<bool> AnyAsync();
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    Task InsertAsync(TEntity entity);
    Task InsertRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> HasChangesAsync();


}
public interface IRepositorySync<TEntity>
  where TEntity : class, IEntity, new()
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Get<TKey>(
      Expression<Func<TEntity, bool>>? predicateExpression = null,
      Expression<Func<TEntity, TKey>>? orderByExpression = null,
      bool isDescending = false,
      int? skip = null,
      int? take = null,
      params Expression<Func<TEntity, object>>[] includeProperties);
    TEntity? Find(params object[] keys);
    TEntity? SingleOrDefault();
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    TEntity? FirstOrDefault();
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    bool Any();
    bool Any(Expression<Func<TEntity, bool>> predicate);
    int Count();
    int Count(Expression<Func<TEntity, bool>> predicate);
    void Insert(TEntity entity);
    void InsertRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    bool HasChanges();


}