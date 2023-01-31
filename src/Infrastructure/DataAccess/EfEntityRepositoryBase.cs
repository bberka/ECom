using ECom.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ECom.Infrastructure.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
			using var context = new TContext();
			return filter == null
				? context.Set<TEntity>().ToList()
				: context.Set<TEntity>().Where(filter).ToList();
		}

        public TEntity Update(TEntity entity)
        {
			using var context = new TContext();
			var updatedEntity = context.Entry(entity);
			updatedEntity.State = EntityState.Modified;
			context.SaveChanges();
			return entity;
		}

		public TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
		{
			using var context = new TContext();
			return context.Set<TEntity>().FirstOrDefault(filter);
		}

		public TEntity? GetFirst(Expression<Func<TEntity, bool>> filter)
		{
			using var context = new TContext();
			return context.Set<TEntity>().First(filter);
		}

		public TEntity? GetSingle(Expression<Func<TEntity, bool>> filter)
		{
			using var context = new TContext();
			return context.Set<TEntity>().Single(filter);
		}

		public TEntity? GetSingleOrDefault(Expression<Func<TEntity, bool>> filter)
		{
			using var context = new TContext();
			return context.Set<TEntity>().SingleOrDefault(filter);
		}

		bool IEntityRepository<TEntity>.Add(TEntity entity)
		{
			using var context = new TContext();
			var addedEntity = context.Entry(entity);
			addedEntity.State = EntityState.Added;
			return context.SaveChanges() == 1;
		}

		public int AddRange(IEnumerable<TEntity> entities)
		{
			using var context = new TContext();
			var addedEntity = context.Entry(entities);
			addedEntity.State = EntityState.Added;
			return context.SaveChanges();
		}

		public int UpdateRange(IEnumerable<TEntity> entities)
		{
			using var context = new TContext();
			var addedEntity = context.Entry(entities);
			addedEntity.State = EntityState.Modified;
			return context.SaveChanges();
		}

		public bool Delete(TEntity entity)
		{
			using var context = new TContext();
			var deletedEntity = context.Entry(entity);
			deletedEntity.State = EntityState.Deleted;
			return context.SaveChanges() == 1;
		}

		public int DeleteRange(IEnumerable<TEntity> entities)
		{
			using var context = new TContext();
			var addedEntity = context.Entry(entities);
			addedEntity.State = EntityState.Deleted;
			return context.SaveChanges();
		}
	}
}
