using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminCategoryService : ICategoryService
{
  List<Category> ListCategories();
  CustomResult UpdateCategory(CategoryAddOrUpdateRequestDto model);
  CustomResult AddCategory(CategoryAddOrUpdateRequestDto model);
  CustomResult DeleteCategory(string key);
  CustomResult RecoverCategory(string key);

}