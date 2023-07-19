namespace ECom.AdminWebApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<AddOrUpdateCategoryRequest>.WithResult<CustomResult>
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
  [EndpointSwaggerOperation(typeof(Update), "Updates category")]
  public override CustomResult Handle(AddOrUpdateCategoryRequest request) {
    var authId = HttpContext.GetAdminId();
    var res = _categoryService.UpdateCategory(request);
    _logService.AdminLog(res, authId, "Category.Update", request.ToJsonString());
    return res;
  }
}