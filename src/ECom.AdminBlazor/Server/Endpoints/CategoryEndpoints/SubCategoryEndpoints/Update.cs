namespace ECom.AdminBlazor.Server.Endpoints.CategoryEndpoints.SubCategoryEndpoints;

//[EndpointRoute(typeof(Update))]
//public class Update : EndpointBaseSync.WithRequest<SubCategory>.WithResult<CustomResult>
//{
//  private readonly ICategoryService _categoryService;
//  private readonly ILogService _logService;

//  public Update(
//    ICategoryService categoryService,
//    ILogService logService) {
//    _categoryService = categoryService;
//    _logService = logService;
//  }

//  [HttpPost]
//  [RequirePermission(AdminOperationType.CategoryUpdate)]
//  [EndpointSwaggerOperation(typeof(Update))]
//  public override CustomResult Handle(SubCategory request) {
//    throw new NotImplementedException();
//    var adminId = HttpContext.GetAdminId();
//    var res = _categoryService.UpdateSubCategory(request);
//    _logService.AdminLog(res, adminId, "SubCategory.Update", request.ToJsonString());
//    return res;
//  }
//}