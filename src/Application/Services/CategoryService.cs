using ECom.Domain.ApiModels.Request;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECom.Domain.Lib;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfEntityRepository<Category> _categoryRepo;
        private readonly IEfEntityRepository<SubCategory> _subCategoryRepo;

        public CategoryService(
            IEfEntityRepository<Category> categoryRepo,
            IEfEntityRepository<SubCategory> subCategoryRepo)
        {
            this._categoryRepo = categoryRepo;
            this._subCategoryRepo = subCategoryRepo;
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
                return DomainResult.Category.NotFoundResult(1);
            }
            if (!CommonLib.IsCultureValid(model.Culture))
            {
                return DomainResult.Language.NotValidResult(2);
            }
            var res = _categoryRepo.UpdateWhereSingle(x => x.Id == model.CategoryId, x =>
            {
                x.IsValid = model.IsValid;
                x.Name = model.Name;
                x.Culture = model.Culture;
            });
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }

            return DomainResult.Category.UpdateSuccessResult();
        }

        public Result UpdateSubCategory(SubCategory model)
        {
            var category = _categoryRepo.Find(model.CategoryId);
            if (category is null)
            {
                return DomainResult.Category.NotFoundResult(1);
            }

            if (!category.IsValid)
            {
                return DomainResult.Category.NotValidResult(2);
            }
            var subCategory = _subCategoryRepo.Find(model.Id);
            if (subCategory is null)
            {
                return DomainResult.SubCategory.NotFoundResult(3);
            }
            if (!subCategory.IsValid)
            {
                return DomainResult.SubCategory.NotValidResult(4);
            }

            var updateResult = _subCategoryRepo.Update(model);
            if (!updateResult)
            {
                return DomainResult.DbInternalErrorResult(5);
            }
            return DomainResult.SubCategory.UpdateSuccessResult();
        }

        public Result DeleteCategory(uint id)
        {
            var category = _categoryRepo.Find((int)id);
            if (category is null)
            {
                return DomainResult.Category.NotFoundResult(1);
            }
            category.IsValid = false;
            var res = _categoryRepo.Update(category);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Category.DeleteSuccessResult();

        }
        public Result EnableOrDisableSubCategory(uint id)
        {
            var category = _subCategoryRepo.Find((int)id);
            if (category == null)
            {
                return DomainResult.SubCategory.NotFoundResult(1);
            }
            category.IsValid = !category.IsValid;
            var res = _subCategoryRepo.Update(category);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.UpdateSuccessResult();
        }
        public Result DeleteSubCategory(uint id)
        {
            var category = _subCategoryRepo.Find((int)id);
            if (category == null)
            {
                return DomainResult.SubCategory.NotFoundResult(1);
            }
            var res = _subCategoryRepo.Delete(category);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.DeleteSuccessResult();
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
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Category.AddSuccessResult();
        }

        public Result AddSubCategory(AddSubCategoryRequestModel model)
        {
            var categoryExists = CategoryExists(model.CategoryId);
            if (!categoryExists)
            {
                return DomainResult.Category.NotFoundResult(1);
            }
            var subCategory = new SubCategory
            {
                Name = model.Name,
                IsValid = true,
                CategoryId = model.CategoryId,
            };
            var res = _subCategoryRepo.Add(subCategory);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.AddSuccessResult();
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryRepo.Any(x => x.Id == categoryId);
        }
    }
}
