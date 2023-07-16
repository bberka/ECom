﻿using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.AdminApi.Endpoints.CategoryEndpoints.SubEndpoints;

[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<AddSubCategoryRequest>.WithResult<CustomResult>
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public Add(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryAdd)]
  [EndpointSwaggerOperation(typeof(Add),"Adds sub category to a main category")]
  public override CustomResult Handle(AddSubCategoryRequest request)
  {
    var res = _categoryService.AddSubCategory(request);
    _logService.AdminLog(res, request.AuthenticatedAdminId, "SubCategory.Add", request.ToJsonString());
    return res;
  }
}