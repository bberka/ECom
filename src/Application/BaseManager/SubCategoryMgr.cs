using Microsoft.EntityFrameworkCore;

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

		
		public Result EnableOrDisable(uint id)
		{
			var category = Find((int)id);
			if (category == null)
			{
				return Result.Error(1, Response.CategoryNotFound);
			}
			category.IsValid = !category.IsValid;
			var res = Update(category);
			if (res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result UpdateSubCategory(SubCategory? category)
		{
			if (category == null)
			{
				return Result.Error(1, Response.CategoryIsNull);
			}
			var res = Update(category);
			if (!res)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result DeleteSubCategory(uint id)
		{
			var category = Find((int)id);
			if (category == null)
			{
				return Result.Error(1, Response.CategoryNotFound);
			}

			var res = Delete(category);
			if (res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryDeleted);

		}
	}
}
