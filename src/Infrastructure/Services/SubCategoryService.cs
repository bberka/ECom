using Microsoft.EntityFrameworkCore;

namespace ECom.Infrastructure.Services
{
	public interface ISubCategoryService : IEfEntityRepository<SubCategory>
	{
		Result DeleteSubCategory(uint id);
		Result EnableOrDisable(uint id);
		Result UpdateSubCategory(SubCategory? category);
	}

	public class SubCategoryService : EfEntityRepositoryBase<SubCategory, EComDbContext>, ISubCategoryService
	{
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
