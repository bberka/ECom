using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminCategoryService : CategoryService, IAdminCategoryService
{
  public AdminCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }
  public List<Category> ListCategories() {
    return UnitOfWork.Categories
      .Where(x => !x.DeleteDate.HasValue)
      .ToList();
  }
  public CustomResult UpdateCategory(CategoryAddOrUpdateRequestDto model) {
    var category = UnitOfWork.Categories.FirstOrDefault(x => x.NameKey == model.NameKey);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    if (!category.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Category));
    category.NameKey = model.NameKey;
    category.ParentNameKey = model.ParentNameKey;
    UnitOfWork.Categories.Update(category);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }


  public CustomResult DeleteCategory(string key) {
    var category = UnitOfWork.Categories.Find(key);
    if (category is null) return DomainResult.NotFound(nameof(Category));
    if (category.DeleteDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Category));
    category.DeleteDate = DateTime.Now;
    UnitOfWork.Categories.Update(category);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteCategory));
    return DomainResult.OkDeleted(nameof(Category));
  }

  public CustomResult RecoverCategory(string key) {
    var category = UnitOfWork.Categories.Find(key);
    if (category == null) return DomainResult.NotFound(nameof(Category));
    if (!category.DeleteDate.HasValue) return DomainResult.OkNotChanged(nameof(Category));
    category.DeleteDate = null;
    UnitOfWork.Categories.Update(category);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RecoverCategory));
    return DomainResult.OkUpdated(nameof(Category));
  }

  public CustomResult AddCategory(CategoryAddOrUpdateRequestDto model) {
    var category = new Category {
      NameKey = model.NameKey,
      ParentNameKey = model.ParentNameKey,
    };
    UnitOfWork.Categories.Add(category);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddCategory));
    return DomainResult.OkAdded(nameof(Category));
  }


}