using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class CategoryService : ICategoryService
{
  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }


  public List<Category> ListCategories() {
    return _unitOfWork.CategoryRepository.Get(x => x.IsValid == true)
      .ToList();
  }


  public CustomResult UpdateCategory(AddOrUpdateCategoryRequest model) {
    var category = _unitOfWork.CategoryRepository.FirstOrDefault(x => x.NameKey == model.NameKey);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    if (!category.IsValid) return DomainResult.Invalid(nameof(Category));
    category.NameKey = model.NameKey;
    category.ParentNameKey = model.ParentNameKey;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }


  public CustomResult DeleteCategory(string key) {
    var category = _unitOfWork.CategoryRepository.Find(key);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    category.IsValid = false;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteCategory));
    return DomainResult.OkDeleted(nameof(Category));
  }




  public CustomResult EnableCategory(string key) {
    var category = _unitOfWork.CategoryRepository.Find(key);
    if (category == null) return DomainResult.NotFound(nameof(Category));
    if (category.IsValid) return DomainResult.AlreadyEnabled(nameof(Category));
    category.IsValid = true;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }

  public CustomResult DisableCategory(string key) {
    var category = _unitOfWork.CategoryRepository.Find(key);
    if (category == null) return DomainResult.NotFound(nameof(Category));
    if (!category.IsValid) return DomainResult.AlreadyDisabled(nameof(Category));
    category.IsValid = false;
    _unitOfWork.CategoryRepository.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }
  public CustomResult AddCategory(AddOrUpdateCategoryRequest model) {
    var category = new Category {
      NameKey = model.NameKey,
      ParentNameKey = model.ParentNameKey,
      IsValid = true
    };
    _unitOfWork.CategoryRepository.Insert(category);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddCategory));
    return DomainResult.OkAdded(nameof(Category));
  }


  public bool CategoryExists(string key) {
    return _unitOfWork.CategoryRepository.Any(x => x.NameKey == key);
  }
}