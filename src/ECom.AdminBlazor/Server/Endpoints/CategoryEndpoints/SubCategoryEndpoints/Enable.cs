namespace ECom.AdminBlazor.Server.Endpoints.CategoryEndpoints.SubCategoryEndpoints;

//[EndpointRoute(typeof(Enable))]
//public class Enable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
//{
//  private readonly ICategoryService _categoryService;
//  private readonly ILogService _logService;

//  public Enable(
//    ICategoryService categoryService,
//    ILogService logService) {
//    _categoryService = categoryService;
//    _logService = logService;
//  }

//  [HttpPost]
//  [RequirePermission(AdminOperationType.SubCategoryEnable)]
//  [EndpointSwaggerOperation(typeof(Enable),"Enables sub category")]
//  public override CustomResult Handle([FromBody] uint id)
//  {

//    var adminId = HttpContext.GetAdminId();
//    var res = _categoryService.EnableSubCategory(id);
//    _logService.AdminLog(res, adminId, "SubCategory.Enable", id);
//    return res;
//  }
//}