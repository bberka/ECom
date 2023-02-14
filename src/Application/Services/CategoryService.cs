using ECom.Domain.DTOs.CategoryDTOs;
using ECom.Domain.Lib;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Category> ListCategories()
        {
            return _unitOfWork.CategoryRepository.Get(x => x.IsValid == true)
                .Include(x => x.SubCategories)
                .ToList();
        }
        public Result EnableOrDisableCategory(uint id)
        {
            var category = _unitOfWork.CategoryRepository.Find((int)id);
            if (category == null) return DomainResult.Category.NotFoundResult(1);
            category.IsValid = !category.IsValid;
            _unitOfWork.CategoryRepository.Update(category);
            var res = _unitOfWork.Save();
            if (!res) return DomainResult.DbInternalErrorResult(2);
            return DomainResult.Category.UpdateSuccessResult();
        }
        public Result UpdateCategory(UpdateCategoryRequest model)
        {
            var data = _unitOfWork.CategoryRepository.GetFirstOrDefault(x => x.Id == model.CategoryId);
            if (data is null)
            {
                return DomainResult.Category.NotFoundResult(1);
            }
            if (!CommonLib.IsCultureValid(model.Culture))
            {
                return DomainResult.Language.NotValidResult(2);
            }
            data.IsValid = model.IsValid;
            data.Name = model.Name;
            data.Culture = model.Culture;
            _unitOfWork.CategoryRepository.Update(data);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(3);
            }
            return DomainResult.Category.UpdateSuccessResult();
        }

        public Result UpdateSubCategory(SubCategory model)
        {
            var category = _unitOfWork.CategoryRepository.Find(model.CategoryId);
            if (category is null)
            {
                return DomainResult.Category.NotFoundResult(1);
            }

            if (!category.IsValid)
            {
                return DomainResult.Category.NotValidResult(2);
            }
            var subCategory = _unitOfWork.SubCategoryRepository.Find(model.Id);
            if (subCategory is null)
            {
                return DomainResult.SubCategory.NotFoundResult(3);
            }
            if (!subCategory.IsValid)
            {
                return DomainResult.SubCategory.NotValidResult(4);
            }
            _unitOfWork.SubCategoryRepository.Update(model);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(5);
            }
            return DomainResult.SubCategory.UpdateSuccessResult();
        }

        public Result DeleteCategory(uint id)
        {
            var category = _unitOfWork.CategoryRepository.Find((int)id);
            if (category is null)
            {
                return DomainResult.Category.NotFoundResult(1);
            }
            category.IsValid = false;
            _unitOfWork.CategoryRepository.Update(category);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Category.DeleteSuccessResult();

        }
        public Result EnableOrDisableSubCategory(uint id)
        {
            var category = _unitOfWork.SubCategoryRepository.Find((int)id);
            if (category == null)
            {
                return DomainResult.SubCategory.NotFoundResult(1);
            }
            category.IsValid = !category.IsValid;
            _unitOfWork.SubCategoryRepository.Update(category);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.UpdateSuccessResult();
        }
        public Result DeleteSubCategory(uint id)
        {
            var category = _unitOfWork.SubCategoryRepository.Find((int)id);
            if (category == null)
            {
                return DomainResult.SubCategory.NotFoundResult(1);
            }
            _unitOfWork.SubCategoryRepository.Delete(category);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.DeleteSuccessResult();
        }

        public Result AddCategory(AddCategoryRequest model)
        {
            var category = new Category
            {
                Culture = model.Culture,
                IsValid = true,
                Name = model.Name,
            };
            _unitOfWork.CategoryRepository.Add(category);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Category.AddSuccessResult();
        }

        public Result AddSubCategory(AddSubCategoryRequest model)
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
            _unitOfWork.SubCategoryRepository.Add(subCategory);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.SubCategory.AddSuccessResult();
        }

        public bool CategoryExists(int categoryId)
        {
            return _unitOfWork.CategoryRepository.Any(x => x.Id == categoryId);
        }
    }
}
