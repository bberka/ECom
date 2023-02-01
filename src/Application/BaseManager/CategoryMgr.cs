using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Application.BaseManager
{
	public class CategoryMgr : EfEntityRepositoryBase<Category, EComDbContext>
	{

		private CategoryMgr() { }
		public static CategoryMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static CategoryMgr? Instance;
	}
}
