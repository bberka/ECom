using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Update))]
public class Update
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Update(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryUpdate)]
  public ActionResult<CustomResult> Update([FromBody] UpdateCategoryRequest model) {
    var res = _categoryService.UpdateCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Category.Update", model.ToJsonString());
    return res.ToActionResult();
  }
}