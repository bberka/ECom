using ECom.Domain.DTOs.CategoryDTOs;
using ECom.Domain.Lib;

namespace ECom.Application.Services;

public class CategoryService : ICategoryService
{
  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Category> ListCategories() {
    return _unitOfWork.CategoryRepository
      .Get(x => x.IsValid == true)
      .Include(x => x.SubCategories)
      .ToList();
  }

  public Result EnableOrDisableCategory(uint id) {
    var category = _unitOfWork.CategoryRepository.GetById((int)id);
    if (category == null) return DomainResult.Category.NotFoundResult();
    category.IsValid = !category.IsValid;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Category.UpdateSuccessResult();
  }

  public Result UpdateCategory(UpdateCategoryRequest model) {
    var data = _unitOfWork.CategoryRepository.GetFirstOrDefault(x => x.Id == model.CategoryId);
    if (data is null) return DomainResult.Category.NotFoundResult();
    if (!CommonLib.IsCultureValid(model.Culture)) return DomainResult.Language.NotValidResult();
    data.IsValid = model.IsValid;
    data.Name = model.Name;
    data.Culture = model.Culture;
    _unitOfWork.CategoryRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Category.UpdateSuccessResult();
  }

  public Result UpdateSubCategory(SubCategory model) {
    var category = _unitOfWork.CategoryRepository.GetById(model.CategoryId);
    if (category is null) return DomainResult.Category.NotFoundResult();

    if (!category.IsValid) return DomainResult.Category.NotValidResult();
    var subCategory = _unitOfWork.SubCategoryRepository.GetById(model.Id);
    if (subCategory is null) return DomainResult.SubCategory.NotFoundResult();
    if (!subCategory.IsValid) return DomainResult.SubCategory.NotValidResult();
    _unitOfWork.SubCategoryRepository.Update(model);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.SubCategory.UpdateSuccessResult();
  }

  public Result DeleteCategory(uint id) {
    var category = _unitOfWork.CategoryRepository.GetById((int)id);
    if (category is null) return DomainResult.Category.NotFoundResult();
    category.IsValid = false;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Category.DeleteSuccessResult();
  }

  public Result EnableOrDisableSubCategory(uint id) {
    var category = _unitOfWork.SubCategoryRepository.GetById((int)id);
    if (category == null) return DomainResult.SubCategory.NotFoundResult();
    category.IsValid = !category.IsValid;
    _unitOfWork.SubCategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.SubCategory.UpdateSuccessResult();
  }

  public Result DeleteSubCategory(uint id) {
    var category = _unitOfWork.SubCategoryRepository.GetById((int)id);
    if (category == null) return DomainResult.SubCategory.NotFoundResult();
    _unitOfWork.SubCategoryRepository.Delete(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.SubCategory.DeleteSuccessResult();
  }

  public Result AddCategory(AddCategoryRequest model) {
    var category = new Category {
      Culture = model.Culture,
      IsValid = true,
      Name = model.Name
    };
    _unitOfWork.CategoryRepository.Insert(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Category.AddSuccessResult();
  }

  public Result AddSubCategory(AddSubCategoryRequest model) {
    var categoryExists = CategoryExists(model.CategoryId);
    if (!categoryExists) return DomainResult.Category.NotFoundResult();
    var subCategory = new SubCategory {
      Name = model.Name,
      IsValid = true,
      CategoryId = model.CategoryId
    };
    _unitOfWork.SubCategoryRepository.Insert(subCategory);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.SubCategory.AddSuccessResult();
  }

  public bool CategoryExists(int categoryId) {
    return _unitOfWork.CategoryRepository.Any(x => x.Id == categoryId);
  }
}