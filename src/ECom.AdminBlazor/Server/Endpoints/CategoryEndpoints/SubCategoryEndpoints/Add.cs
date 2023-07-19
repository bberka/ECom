namespace ECom.AdminBlazor.Server.Endpoints.CategoryEndpoints.SubCategoryEndpoints;

//[EndpointRoute(typeof(Create))]
//public class Create : EndpointBaseSync.WithRequest<AddOrUpdateCategoryRequest>.WithResult<CustomResult>
//{
//  private readonly ICategoryService _categoryService;
//  private readonly ILogService _logService;

//  public Create(
//    ICategoryService categoryService,
//    ILogService logService) {
//    _categoryService = categoryService;
//    _logService = logService;
//  }

//  [HttpPost]
//  [RequirePermission(AdminOperationType.CategoryAdd)]
//  [EndpointSwaggerOperation(typeof(Create),"Adds sub category to a main category")]
//  public override CustomResult Handle(AddOrUpdateCategoryRequest request)
//  {
//    var res = _categoryService.AddSubCategory(request);
//    _logService.AdminLog(res, request.AuthenticatedAdminId, "SubCategory.Create", request.ToJsonString());
//    return res;
//  }
//}