using ECom.Domain.ApiModels.Request;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Application.Services
{
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
			if (category == null) throw new NotFoundException(nameof(Category));
			category.IsValid = !category.IsValid;
			var res = _categoryRepo.Update(category);
			if (!res) throw new DbInternalException(nameof(EnableOrDisableCategory));
			return Result.Success(ErrCode.NotFound);
		}
		public Result UpdateCategory(CategoryUpdateRequestModel model)
		{
			if (!_categoryRepo.Any(x => x.Id == model.CategoryId)) throw new NotFoundException(nameof(Category));
            if (!_languageRepo.Any(x => x.Id == model.LanguageId)) throw new NotFoundException(nameof(Language));
            var res = _categoryRepo.UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
			{
				x.IsValid = model.IsValid;
				x.Name = model.Name;
				x.LanguageId = model.LanguageId;
			});
            if (!res) throw new DbInternalException(nameof(EnableOrDisableCategory));
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteCategory(uint id)
		{
			var category = _categoryRepo.Find((int)id);
			if (category == null) throw new NotFoundException(nameof(Category));
            var res = _categoryRepo.Delete(category);
            if (!res) throw new DbInternalException(nameof(DeleteCategory));
			return Result.Success(ErrCode.Deleted);

		}
		public Result EnableOrDisableSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
            if (category == null) throw new NotFoundException(nameof(Category));
			category.IsValid = !category.IsValid;
			var res = _subCategoryRepo.Update(category);
            if (!res) throw new DbInternalException(nameof(EnableOrDisableSubCategory));
			return Result.Success("Updated");
		}
		public Result UpdateSubCategory(SubCategory? data)
		{
			if (data == null) throw new NullException(nameof(SubCategory));
			var res = _subCategoryRepo.Update(data);
            if (!res) throw new DbInternalException(nameof(UpdateSubCategory));
			return Result.Success("Updated");
		}
		public Result DeleteSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
            if (category == null) throw new NullException(nameof(SubCategory));
			var res = _subCategoryRepo.Delete(category);
            if (category == null) throw new DbInternalException(nameof(DeleteSubCategory));
			return Result.Success("Deleted");
		}
	}
}
