namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Delete))]
public class Delete : EndpointBaseSync.WithRequest<string>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Delete(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.CategoryDelete)]
  [EndpointSwaggerOperation(typeof(Delete))]
  public override CustomResult Handle([FromBody] string key)
  {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteCategory(key);
    _logService.AdminLog(res, adminId, "Category.Delete", key);
    return res;
  }
}