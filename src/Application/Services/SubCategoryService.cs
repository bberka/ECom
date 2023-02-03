using Microsoft.EntityFrameworkCore;

namespace ECom.Application.Services
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
				return Result.Error(1, ErrCode.NotFound);
			}
			category.IsValid = !category.IsValid;
			var res = Update(category);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateSubCategory(SubCategory? data)
		{
			if (data == null)
			{
				return Result.Error(1, ErrCode.NullReference);
			}
			var res = Update(data);
			if (!res)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteSubCategory(uint id)
		{
			var category = Find((int)id);
			if (category == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}

			var res = Delete(category);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.Deleted);

		}
	}
}
