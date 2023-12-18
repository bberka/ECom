using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminCategoryService
{
  Result UpdateCategoryOrdering(List<NestableListElementDto> categories);
  Result AddCategory(Request_Category_Add model);
  Result DeleteCategory(string key);
  Result UpdateCategory(Request_Category_Update model);
}