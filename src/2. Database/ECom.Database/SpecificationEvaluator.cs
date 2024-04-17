using ECom.Database.Abstract;
using ECom.Foundation.Abstract;

namespace ECom.Database;

public static class SpecificationEvaluator
{
  public static IQueryable<TEntity> GetQuery<TEntity>(this DbSet<TEntity> dbSet,
                                                      ISpecification<TEntity> specification,
                                                      bool noTracking = false) where TEntity : class, IEntity {
    return specification.GetQuery(dbSet);
  }
}