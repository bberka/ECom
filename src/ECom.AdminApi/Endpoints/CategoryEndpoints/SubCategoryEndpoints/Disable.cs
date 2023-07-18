namespace ECom.AdminApi.Endpoints.CategoryEndpoints.SubCategoryEndpoints;

//[EndpointRoute(typeof(Disable))]
//public class Disable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
//{
//  private readonly ICategoryService _categoryService;
//  private readonly ILogService _logService;

//  public Disable(
//    ICategoryService categoryService,
//    ILogService logService) {
//    _categoryService = categoryService;
//    _logService = logService;
//  }

//  [HttpPost]
//  [RequirePermission(AdminOperationType.SubCategoryDisable)]
//  [EndpointSwaggerOperation(typeof(Disable))]
//  public override CustomResult Handle([FromBody] uint id)
//  {
//    throw new NotImplementedException();

//    var adminId = HttpContext.GetAdminId();
//    var res = _categoryService.EnableSubCategory(id);
//    _logService.AdminLog(res, adminId, "SubCategory.Disable", id);
//    return res;
//  }
//}