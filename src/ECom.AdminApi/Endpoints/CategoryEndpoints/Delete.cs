namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Delete))]
public class Delete : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
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
  public override CustomResult Handle([FromBody] uint id)
  {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteCategory(id);
    _logService.AdminLog(res, adminId, "Category.Delete", id);
    return res;
  }
}