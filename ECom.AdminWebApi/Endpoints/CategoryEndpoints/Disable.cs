namespace ECom.AdminWebApi.Endpoints.CategoryEndpoints;

//[EndpointRoute(typeof(Disable))]
//public class Disable : EndpointBaseSync.WithRequest<string>.WithResult<CustomResult>
//{
//  private readonly ICategoryService _categoryService;
//  private readonly ILogService _logService;

//  public Disable(
//    ICategoryService categoryService,
//    ILogService logService) {
//    _categoryService = categoryService;
//    _logService = logService;
//  }

//  [HttpPut]
//  [RequirePermission(AdminOperationType.CategoryDisable)]
//  [EndpointSwaggerOperation(typeof(Disable))]
//  public override CustomResult Handle([FromBody] string key)
//  {
//    var adminId = HttpContext.GetAdminId();
//    var res = _categoryService.DisableCategory(key);
//    _logService.AdminLog(res, adminId, "Category.Disable", key);
//    return res;
//  }
//}