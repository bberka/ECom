using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminCategoryService : ICategoryService
{
  List<Category> ListCategories();
  CustomResult UpdateCategory(AddOrUpdateCategoryRequest model);
  CustomResult AddCategory(AddOrUpdateCategoryRequest model);
  CustomResult DeleteCategory(string key);
  CustomResult RecoverCategory(string key);

}