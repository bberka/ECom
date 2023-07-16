using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.AdminApi.Endpoints.CategoryEndpoints;

[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<AddCategoryRequest>.WithResult<CustomResult>
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
  public override CustomResult Handle(AddCategoryRequest request)
  {
    var res = _categoryService.AddCategory(request);
    _logService.AdminLog(res, request.AuthenticatedAdminId, "Category.Add", request.ToJsonString());
    return res;
  }


}