using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class CollectionProductMgr : EfEntityRepositoryBase<CollectionProduct, EComDbContext>
	{

		private CollectionProductMgr() { }
		public static CollectionProductMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CollectionProductMgr? Instance;
	}
}
