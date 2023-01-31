using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DataAccess
{
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
		public List<T> GetList(Expression<Func<T,bool>>?  filter = null);
        public T? GetFirstOrDefault(Expression<Func<T,bool>> filter);
        public T? GetFirst(Expression<Func<T,bool>> filter);
        public T? GetSingle(Expression<Func<T,bool>> filter);
        public T? GetSingleOrDefault(Expression<Func<T,bool>> filter);
        public bool Add(T entity);
        public int AddRange(IEnumerable<T> entities);
        public T Update(T entity);
		public int UpdateRange(IEnumerable<T> entities);
        public bool Delete(T entity);
		public int DeleteRange(IEnumerable<T> entities);
    }
}
