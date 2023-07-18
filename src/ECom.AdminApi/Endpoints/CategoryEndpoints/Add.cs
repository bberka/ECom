using ECom.Domain.DTOs.CategoryDto;

namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<AddOrUpdateCategoryRequest>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Add(ICategoryService categoryService, ILogService logService)
  {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryAdd)]
  [EndpointSwaggerOperation(typeof(Add),"Adds category")]
  public override CustomResult Handle(AddOrUpdateCategoryRequest request)
  {
    var res = _categoryService.AddCategory(request);
    _logService.AdminLog(res, request.AuthenticatedAdminId, "Category.Create", request.ToJsonString());
    return res;
  }


}