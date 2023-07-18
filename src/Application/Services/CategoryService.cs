using ECom.Domain;
using ECom.Domain.DTOs.CategoryDto;
using ECom.Domain.Lib;

namespace ECom.Application.Services;

public class CategoryService : ICategoryService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILocalizationService _localizationService;

  public CategoryService(IUnitOfWork unitOfWork, ILocalizationService localizationService) {
    _unitOfWork = unitOfWork;
    _localizationService = localizationService;
  }



  public List<Category> ListCategories() {
    return _unitOfWork.CategoryRepository
      .Get(x => x.IsValid == true)
      .ToList();
  }



  public CustomResult UpdateCategory(AddOrUpdateCategoryRequest model) {
    var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(x => x.NameKey == model.NameKey);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    if (!category.IsValid) return DomainResult.Invalid(nameof(Category));
    category.NameKey = model.NameKey;
    category.ParentNameKey = model.ParentNameKey;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCategory));
    var languageUpdateResult = _localizationService.AddOrUpdateLocalization(new LocalizationString {
      Key = model.NameKey,
      Language = model.Language,
      Value = model.Name
    });
    if (!languageUpdateResult.Status) return languageUpdateResult;
    return DomainResult.OkUpdated(nameof(Category));
  }

  //public CustomResult UpdateSubCategory(SubCategory model) {
  //  var category = _unitOfWork.CategoryRepository.GetById(model.CategoryId);
  //  if (category is null) return DomainResult.NotFound(nameof(Category));
  //  if (!category.IsValid) return DomainResult.Invalid(nameof(Category));
  //  var subCategory = _unitOfWork.SubCategoryRepository.GetById(model.Id);
  //  if (subCategory is null) return DomainResult.NotFound(nameof(SubCategory));
  //  if (!subCategory.IsValid) return DomainResult.Invalid(nameof(SubCategory));
  //  _unitOfWork.SubCategoryRepository.Update(model);
  //  var res = _unitOfWork.Save();
  //  if (!res) return DomainResult.DbInternalError(nameof(UpdateSubCategory));
  //  return DomainResult.OkUpdated("SubCategory");
  //}

  public CustomResult DeleteCategory(string key) {
    var category = _unitOfWork.CategoryRepository.GetById(key);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    category.IsValid = false;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteCategory));
    return DomainResult.OkDeleted(nameof(Category));
  }



  //public CustomResult DeleteSubCategory(uint id) {
  //  var category = _unitOfWork.SubCategoryRepository.GetById((int)id);
  //  if (category == null) return DomainResult.NotFound(nameof(SubCategory));
  //  _unitOfWork.SubCategoryRepository.Delete(category);
  //  var res = _unitOfWork.Save();
  //  if (!res) return DomainResult.DbInternalError(nameof(DeleteSubCategory));
  //  return DomainResult.OkDeleted(nameof(SubCategory));
  //}


  public CustomResult EnableCategory(string key) {
    var category = _unitOfWork.CategoryRepository.GetById(key);
    if (category == null) return DomainResult.NotFound(nameof(Category));
    if (category.IsValid) return DomainResult.AlreadyEnabled(nameof(Category));
    category.IsValid = true;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }

  public CustomResult DisableCategory(string key) {
    var category = _unitOfWork.CategoryRepository.GetById(key);
    if (category == null) return DomainResult.NotFound(nameof(Category));
    if (!category.IsValid) return DomainResult.AlreadyDisabled(nameof(Category));
    category.IsValid = false;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }

  //public CustomResult DisableSubCategory(uint id) {
  //  var category = _unitOfWork.SubCategoryRepository.GetById((int)id);
  //  if (category == null) return DomainResult.NotFound(nameof(SubCategory));
  //  if(!category.IsValid) return DomainResult.AlreadyDisabled(nameof(SubCategory));
  //  category.IsValid = false;
  //  _unitOfWork.SubCategoryRepository.Update(category);
  //  var res = _unitOfWork.Save();
  //  if (!res) return DomainResult.DbInternalError(nameof(DisableSubCategory));
  //  return DomainResult.OkUpdated(nameof(SubCategory));
  //}

  //public CustomResult EnableSubCategory(uint id) {
  //  var category = _unitOfWork.SubCategoryRepository.GetById((int)id);
  //  if (category == null) return DomainResult.NotFound(nameof(SubCategory));
  //  if (category.IsValid) return DomainResult.AlreadyEnabled(nameof(SubCategory));
  //  category.IsValid = true;
  //  _unitOfWork.SubCategoryRepository.Update(category);
  //  var res = _unitOfWork.Save();
  //  if (!res) return DomainResult.DbInternalError(nameof(EnableSubCategory));
  //  return DomainResult.OkUpdated(nameof(SubCategory));
  //}

  public CustomResult AddCategory(AddOrUpdateCategoryRequest model) {
    var category = new Category {
      NameKey = model.NameKey,
      ParentNameKey = model.ParentNameKey,
      IsValid = true,
    };
    _unitOfWork.CategoryRepository.Insert(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddCategory));
    var languageUpdateResult = _localizationService.AddOrUpdateLocalization(new LocalizationString {
      Key = model.NameKey,
      Language = model.Language,
      Value = model.Name
    });
    if (!languageUpdateResult.Status) return languageUpdateResult;
    return DomainResult.OkAdded(nameof(Category));
  }

  //public CustomResult AddSubCategory(AddSubCategoryRequest model) {
  //  var categoryExists = CategoryExists(model.CategoryId);
  //  if (!categoryExists) return DomainResult.NotFound(nameof(SubCategory));
  //  var subCategory = new SubCategory {
  //    Name = model.Name,
  //    IsValid = true,
  //    CategoryId = model.CategoryId
  //  };
  //  _unitOfWork.SubCategoryRepository.Insert(subCategory);
  //  var res = _unitOfWork.Save();
  //  if (!res) return DomainResult.DbInternalError(nameof(AddCategory));
  //  return DomainResult.OkAdded(nameof(SubCategory));
  //}

  public bool CategoryExists(string key) {
    return _unitOfWork.CategoryRepository.Any(x => x.NameKey == key);
  }
}