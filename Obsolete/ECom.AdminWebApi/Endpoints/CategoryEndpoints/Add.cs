namespace ECom.AdminWebApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<AddOrUpdateCategoryRequest>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Add(ICategoryService categoryService, ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminPermission.ManageCategories)]
  [EndpointSwaggerOperation(typeof(Add), "Adds category")]
  public override CustomResult Handle(AddOrUpdateCategoryRequest request) {
    var authId = HttpContext.GetAdminId();
    var res = _categoryService.AddCategory(request);
    _logService.AdminLog(res, authId, "Category.Create", request.ToJsonString());
    return res;
  }
}