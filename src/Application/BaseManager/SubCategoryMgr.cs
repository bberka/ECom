namespace ECom.Application.BaseManager
{
	public class SubCategoryMgr : EfEntityRepositoryBase<SubCategory, EComDbContext>
	{

		private SubCategoryMgr() { }
		public static SubCategoryMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static SubCategoryMgr? Instance;
	}
}
