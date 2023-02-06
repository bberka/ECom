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
				.ToList();
		}
		public Result EnableOrDisableCategory(uint id)
		{
			var category = _categoryRepo.Find((int)id);
			if (category == null) throw new NotFoundException(nameof(Category));
			category.IsValid = !category.IsValid;
			var res = _categoryRepo.Update(category);
			if (!res) throw new DbInternalException(nameof(EnableOrDisableCategory));
			return Result.Success();
		}
		public Result UpdateCategory(CategoryUpdateRequestModel model)
		{
			if (!_categoryRepo.Any(x => x.Id == model.CategoryId))
			{
				return Result.Warn(1, ErrorCode.NotFound, nameof(Category));
            }
            if (!_languageRepo.Any(x => x.Culture == model.Culture))
            {
                return Result.Warn(1, ErrorCode.NotFound, nameof(Language));
            }
            var res = _categoryRepo.UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
			{
				x.IsValid = model.IsValid;
				x.Name = model.Name;
				x.Culture = model.Culture;
			});
            if (!res) 
			{
                return Result.DbInternal(3);
            }
			return Result.Success();
		}
		public Result DeleteCategory(uint id)
		{
			var category = _categoryRepo.Find((int)id);
			if (category is null) 
			{
                return Result.Warn(1, ErrorCode.NotFound, nameof(Category));
            }
			category.IsValid = false;
            var res = _categoryRepo.Update(category);
            if (!res) 
			{
                return Result.DbInternal(2);
            }
			return Result.Success();

		}
		public Result EnableOrDisableSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
            if (category == null) 
			{
                return Result.Warn(1, ErrorCode.NotFound, nameof(Category));
            }
			category.IsValid = !category.IsValid;
			var res = _subCategoryRepo.Update(category);
            if (!res) 
			{
				return Result.DbInternal(2);
            }
			return Result.Success();
		}
		public Result UpdateSubCategory(SubCategory? data)
		{
			if (data == null) 
			{
                return Result.Warn(1, ErrorCode.NotFound, nameof(SubCategory));
            }
			var res = _subCategoryRepo.Update(data);
            if (!res) 
			{
                return Result.DbInternal(2);
            }
			return Result.Success("Updated");
		}
		public Result DeleteSubCategory(uint id)
		{
			var category = _subCategoryRepo.Find((int)id);
            if (category == null) 
			{
                return Result.Warn(1, ErrorCode.NotFound, nameof(SubCategory));
            }
			var res = _subCategoryRepo.Delete(category);
            if (category == null) 
			{
                return Result.DbInternal(2);
            }
			return Result.Success("Deleted");
		}

        public Result AddCategory(AddCategoryRequestModel model)
        {
			var category = new Category
			{
				Culture = model.Culture,
				IsValid = true,
				Name = model.Name,
			};
			var res = _categoryRepo.Add(category);
			if (!res)
			{
				return Result.DbInternal(1);
			}
			return Result.Success();
		}

        public Result AddSubCategory(AddCategoryRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
