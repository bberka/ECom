using Microsoft.EntityFrameworkCore;
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
			if(category == null)
			{
				return Result.Error(1, Response.CategoryNotFound);
			}
			category.IsValid = !category.IsValid;
			var res = Update(category);
			if(res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result UpdateCategory(CategoryUpdateModel model)
		{
			if (!Any(x => x.Id == model.CategoryId))
			{
				return Result.Error(1, Response.CategoryNotFound);
			}
			if (!LanguageMgr.This.Any(x => x.Id == model.LanguageId))
			{
				return Result.Error(3, Response.LanguageNotFound);
			}
			var res = UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
			{
				x.IsValid = model.IsValid;
				x.Name = model.Name;
				x.LanguageId = model.LanguageId;
			});
			if (!res)
			{
				return Result.Error(4, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result DeleteCategory(uint id)
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
