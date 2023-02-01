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
			using var ctx = new EComDbContext();
			return ctx.Categories
				.Where(x => x.IsValid == true)
				.Include(x => x.SubCategories)
				.Include(x => x.Language)
				.Include(x => x.Image)
				.ToList();
		}
		public Result EnableOrDisableCategory(int id)
		{
			var category = Find(id);
			if(category == null)
			{
				return Result.Error(1, Response.CategoryNotExists);
			}
			category.IsValid = !category.IsValid;
			var res = Update(category);
			if(res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result UpdateCategory(Category? category)
		{
			if (category == null)
			{
				return Result.Error(1,Response.CategoryIsNull);
			}
			var res = Update(category);
			if (!res)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.CategoryUpdated);
		}
		public Result DeleteCategory(int id)
		{
			var category = Find(id);
			if (category == null)
			{
				return Result.Error(1, Response.CategoryNotExists);
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
