using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminCategoryService : ICategoryService
{
  List<Category> ListCategories();
  CustomResult UpdateCategory(AddOrUpdateCategoryRequest model);
  CustomResult AddCategory(AddOrUpdateCategoryRequest model);
  CustomResult DeleteCategory(string key);
  CustomResult RecoverCategory(string key);

}