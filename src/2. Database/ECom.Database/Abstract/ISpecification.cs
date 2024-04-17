using System.Linq.Expressions;
using ECom.Foundation.Abstract;

namespace ECom.Database.Abstract;

public interface ISpecification<TEntity> where TEntity : IEntity
{
  public abstract IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery);
}