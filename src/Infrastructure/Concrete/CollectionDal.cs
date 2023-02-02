using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Concrete
{
	public class CollectionDal : EfEntityRepositoryBase<Collection, EComDbContext>
	{

		private CollectionDal() { }
		public static CollectionDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CollectionDal? Instance;
	}
}
