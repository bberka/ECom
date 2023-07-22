﻿using System.Linq.Expressions;

namespace ECom.Domain.EfAbstractions;
public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
  where TEntity : class, IEntity, new()
{
  protected readonly DbContext DbContext;
  protected DbSet<TEntity> Table => DbContext.Set<TEntity>();
  protected RepositoryBase(DbContext dbContext) {
    DbContext = dbContext;
  }

  public async Task<IQueryable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate) {
    var query = Table.Where(predicate);
    return await Task.FromResult(query);
  }

  public async Task<IEnumerable<TEntity>> SelectAsync<TKey>(
    Expression<Func<TEntity, bool>>? predicateExpression = null,
    Expression<Func<TEntity, TKey>>? orderByExpression = null,
    bool isDescending = false,
    int? skip = null, 
    int? take = null, 
    params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.AsQueryable();
    if (predicateExpression is not null) {
      queryable = queryable.Where(predicateExpression);
    }
    foreach (var includeProperty in includeProperties) {
      if(includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    if(orderByExpression is not null)
      queryable = isDescending ? queryable.OrderByDescending(orderByExpression) : queryable.OrderBy(orderByExpression);
    var skipped = skip.HasValue ? queryable.Skip(skip.Value) : queryable;
    var taken = take.HasValue ? skipped.Take(take.Value) : skipped;
    return await Task.FromResult(taken.AsEnumerable());
  }

  public async Task<TEntity?> FindAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector) {
    var keys = keySelector.Parameters.Select(p => p.Name).Cast<object>().Where(x => x is not null).ToArray();
    var entity = await Table.FindAsync(keys);
    return await Task.FromResult(entity);
    
  }

  public async Task<TEntity?> SingleOrDefaultAsync() {
    var entity = await Table.SingleOrDefaultAsync();
    return await Task.FromResult(entity);
  }

  public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
    var entity = await Table.SingleOrDefaultAsync(predicate);
    return await Task.FromResult(entity);
  }

  public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.Where(predicate);
    foreach (var includeProperty in includeProperties) {
      if(includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    var entity = await queryable.SingleOrDefaultAsync();
    return await Task.FromResult(entity);
  }

  public async Task<TEntity?> FirstOrDefaultAsync() {
    var entity = await Table.FirstOrDefaultAsync();
    return await Task.FromResult(entity);
  }

  public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
    var entity = await Table.FirstOrDefaultAsync(predicate);
    return await Task.FromResult(entity);
  }

  public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.Where(predicate);
    foreach (var includeProperty in includeProperties) {
      if(includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    var entity = await queryable.FirstOrDefaultAsync();
    return await Task.FromResult(entity);
  }

  public async Task<bool> AnyAsync() {
    var queryable = await Table.AnyAsync();
    return await Task.FromResult(queryable);
  }

  public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
    var queryable = await Table.AnyAsync(predicate);
    return await Task.FromResult(queryable);
  }

  public async Task<int> CountAsync() {
    var queryable = await Table.CountAsync();
    return await Task.FromResult(queryable);
  }

  public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) {
    var queryable = await Table.CountAsync(predicate);
    return await Task.FromResult(queryable);
  }

  public async Task InsertAsync(TEntity entity) {
    await Table.AddAsync(entity);
  }

  public async Task InsertRangeAsync(IEnumerable<TEntity> entities) {
    await Table.AddRangeAsync(entities);
  }


  public async Task<bool> HasChangesAsync() {
    var hasChanges = await Task.FromResult(DbContext.ChangeTracker.HasChanges());
    return hasChanges;
  }

  public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate) {
    var query = Table.Where(predicate);
    return query;
  }

  public IEnumerable<TEntity> Select<TKey>(
    Expression<Func<TEntity, bool>>? predicateExpression = null, 
    Expression<Func<TEntity, TKey>>? orderByExpression = null, 
    bool isDescending = false,
    int? skip = null, 
    int? take = null, 
    params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.AsQueryable();
    if (predicateExpression is not null) {
      queryable = queryable.Where(predicateExpression);
    }
    foreach (var includeProperty in includeProperties) {
      if (includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    if (orderByExpression is not null)
      queryable = isDescending ? queryable.OrderByDescending(orderByExpression) : queryable.OrderBy(orderByExpression);
    var skipped = skip.HasValue ? queryable.Skip(skip.Value) : queryable;
    var taken = take.HasValue ? skipped.Take(take.Value) : skipped;
    return taken.AsEnumerable();
  }

  public TEntity? Find<TKey>(Expression<Func<TEntity, TKey>> keySelector) {
    var keys = keySelector.Parameters.Select(p => p.Name).Cast<object>().Where(x => x is not null).ToArray();
    var entity = Table.Find(keys);
    return entity;
  }


  public TEntity? SingleOrDefault() {
    var entity = Table.SingleOrDefault();
    return entity;
  }

  public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate) {
    var entity = Table.SingleOrDefault(predicate);
    return entity;
  }

  public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.Where(predicate);
    foreach (var includeProperty in includeProperties) {
      if(includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    var entity = queryable.SingleOrDefault();
    return entity;
  }

  public TEntity? FirstOrDefault() {
    var entity = Table.FirstOrDefault();
    return entity;
  }

  public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate) {
    var entity = Table.FirstOrDefault(predicate);
    return entity;
  }

  public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties) {
    var queryable = Table.Where(predicate);
    foreach (var includeProperty in includeProperties) {
      if(includeProperty.Name is null) continue;
      queryable = queryable.Include(includeProperty);
    }
    var entity = queryable.FirstOrDefault();
    return entity;
  }

  public bool Any() {
    var queryable = Table.Any();
    return queryable;
  }

  public bool Any(Expression<Func<TEntity, bool>> predicate) {
    var queryable = Table.Any(predicate);
    return queryable;
  }

  public int Count() {
    var queryable = Table.Count();
    return queryable;
  }

  public int Count(Expression<Func<TEntity, bool>> predicate) {
    var queryable = Table.Count(predicate);
    return queryable;
  }

  public void Insert(TEntity entity) {
    Table.Add(entity);
  }

  public void InsertRange(IEnumerable<TEntity> entities) {
    Table.AddRange(entities);
  }

  public void Update(TEntity entity) {
    Table.Update(entity);
  }

  public void UpdateRange(IEnumerable<TEntity> entities) {
    Table.UpdateRange(entities);
  }

  public void Delete(TEntity entity) {
    Table.Remove(entity);
  }

  public void DeleteRange(IEnumerable<TEntity> entities) {
    Table.RemoveRange(entities);
  }

  public bool HasChanges() {
    var hasChanges = DbContext.ChangeTracker.HasChanges();
    return hasChanges;
  }
}

public abstract class RepositoryBase<TContext, TEntity> : RepositoryBase<TEntity>
  where TContext : DbContext
  where TEntity : class, IEntity, new()
{
  protected RepositoryBase(TContext dbContext) : base(dbContext) {

  }
}
