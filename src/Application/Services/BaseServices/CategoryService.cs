using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;

namespace ECom.Application.Services.BaseServices;

public abstract class CategoryService : ICategoryService
{
  protected IUnitOfWork UnitOfWork { get; }

  protected CategoryService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }
  public List<CategoryDto> ListCategoriesDto() {
    return UnitOfWork.CategoryRepository
      .Get(x => x.DeleteDate.HasValue)
      .Select(x => new CategoryDto() {
        Order = x.Order,
        NameKey = x.NameKey,
        //TODO: Add ParentNameKey
      })
      .ToList();
  }
}