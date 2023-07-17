namespace ECom.AdminApi.Endpoints.CategoryEndpoints.SubCategoryEndpoints;

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
  [RequirePermission(AdminOperationType.CargoOptionDelete)]
  [EndpointSwaggerOperation(typeof(Delete))]
  public override CustomResult Handle([FromBody] string id)
  {
    throw new NotImplementedException();
    //var adminId = HttpContext.GetAdminId();
    //var res = _categoryService.DeleteSubCategory(id);
    //_logService.AdminLog(res, adminId, "SubCategory.Delete", id);
    //return res;
  }
}