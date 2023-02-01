using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.BaseManager
{
	public class CollectionMgr : EfEntityRepositoryBase<Collection, EComDbContext>
	{

		private CollectionMgr() { }
		public static CollectionMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CollectionMgr? Instance;
	}
}
