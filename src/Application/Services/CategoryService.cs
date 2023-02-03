using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Application.Services
{
	public interface ICategoryService
	{
		Result DeleteCategory(uint id);
		Result DeleteSubCategory(uint id);
		Result EnableOrDisableCategory(uint id);
		Result EnableOrDisableSubCategory(uint id);
		List<Category> ListCategories();
		Result UpdateCategory(CategoryUpdateModel model);
		Result UpdateSubCategory(SubCategory? data);
	}

	public class CategoryService : ICategoryService
	{
		private readonly IEfEntityRepository<Category> _categoryRepo;
		private readonly IEfEntityRepository<SubCategory> _subCategoryRepo;
		private readonly IEfEntityRepository<Language> _languageRepo;

		public CategoryService(
			IEfEntityRepository<Category> categoryRepo,
			IEfEntityRepository<SubCategory> subCategoryRepo,
			IEfEntityRepository<Language> languageRepo)
		{
			this._categoryRepo = categoryRepo;
			this._subCategoryRepo = subCategoryRepo;
			this._languageRepo = languageRepo;
		}
		public List<Category> ListCategories()
		{
			return _categoryRepo.Get(x => x.IsValid == true)
				.Include(x => x.SubCategories)
				.Include(x => x.Language)
				.ToList();
		}
		public Result EnableOrDisableCategory(uint id)
		{
			var category = _categoryRepo.Find((int)id);
			if (category == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			category.IsValid = !category.IsValid;
			var res = _categoryRepo.Update(category);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateCategory(CategoryUpdateModel model)
		{
			if (!_categoryRepo.Any(x => x.Id == model.CategoryId))
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			if (!_languageRepo.Any(x => x.Id == model.LanguageId))
			{
				return Result.Error(3, ErrCode.NotFound);
			}
			var res = _categoryRepo.UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
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
			var category = _categoryRepo.Find((int)id);
			if (category == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			var res = _categoryRepo.Delete(category);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.Deleted);

		}
		public Result EnableOrDisableSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
			if (category == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			category.IsValid = !category.IsValid;
			var res = _subCategoryRepo.Update(category);
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
			var res = _subCategoryRepo.Update(data);
			if (!res)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
			if (category == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}

			var res = _subCategoryRepo.Delete(category);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.Deleted);

		}
	}
}
