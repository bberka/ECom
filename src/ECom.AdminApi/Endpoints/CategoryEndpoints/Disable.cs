namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Disable))]
public class Disable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Disable(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.CategoryDisable)]
  [EndpointSwaggerOperation(typeof(Disable))]
  public override CustomResult Handle([FromBody] uint id)
  {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DisableCategory(id);
    _logService.AdminLog(res, adminId, "Category.Disable", id);
    return res;
  }
}