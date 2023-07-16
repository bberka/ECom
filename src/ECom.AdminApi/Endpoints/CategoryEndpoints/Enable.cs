namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Enable))]
public class Enable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Enable(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.CategoryEnable)]
  [EndpointSwaggerOperation(typeof(Enable),"Enables category")]
  public override CustomResult Handle(uint request)
  {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableCategory(request);
    _logService.AdminLog(res, adminId, "Category.Enable", request);
    return res;
  }
}