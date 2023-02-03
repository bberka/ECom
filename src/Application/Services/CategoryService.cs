using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Application.Services
{
	public interface ICategoryService : IEfEntityRepository<Category>
	{
		Result DeleteCategory(uint id);
		Result EnableOrDisable(uint id);
		List<Category> ListCategories();
		Result UpdateCategory(CategoryUpdateModel model);
	}

	public class CategoryService : EfEntityRepositoryBase<Category, EComDbContext>, ICategoryService
	{
		public List<Category> ListCategories()
		{
			return Get(x => x.IsValid == true)
				.Include(x => x.SubCategories)
				.Include(x => x.Language)
				.ToList();
		}
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
		public Result UpdateCategory(CategoryUpdateModel model)
		{
			if (!Any(x => x.Id == model.CategoryId))
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			var langService = new LanguageService();
			if (!langService.Any(x => x.Id == model.LanguageId))
			{
				return Result.Error(3, ErrCode.NotFound);
			}
			var res = UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
			{
				x.IsValid = model.IsValid;
				x.Name = model.Name;
				x.LanguageId = model.LanguageId;
			});
			if (!res)
			{
				return Result.Error(4, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteCategory(uint id)
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
