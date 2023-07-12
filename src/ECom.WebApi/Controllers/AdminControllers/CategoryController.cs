
using ECom.Domain.DTOs.CategoryDTOs;

namespace ECom.WebApi.Controllers.AdminControllers;

public class CategoryController : BaseAdminController
{
  private readonly ICategoryService _categoryService;
  private readonly ILogService _logService;

  public CategoryController(
    ICategoryService categoryService,
    ILogService logService) {
    _categoryService = categoryService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Category_Add)]
  public ActionResult<Result> AddCategory([FromBody] AddCategoryRequest model) {
    var res = _categoryService.AddCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Category.Add", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Category_Add)]
  public ActionResult<Result> AddSubCategory([FromBody] AddSubCategoryRequest model) {
    var res = _categoryService.AddSubCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "SubCategory.Add", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Category_Update)]
  public ActionResult<Result> Update([FromBody] UpdateCategoryRequest model) {
    var res = _categoryService.UpdateCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Category.Update", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.Category_Delete)]
  public ActionResult<Result> Delete([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteCategory(id);
    _logService.AdminLog(res, adminId, "Category.Delete", id);
    return res.ToActionResult();
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.Category_Update)]
  public ActionResult<Result> EnableOrDisable([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableOrDisableCategory(id);
    _logService.AdminLog(res, adminId, "Category.Update", id);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.Category_Update)]
  public ActionResult<Result> UpdateSubCategory([FromBody] SubCategory category) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.UpdateSubCategory(category);
    _logService.AdminLog(res, adminId, "SubCategory.Update", category.ToJsonString());
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.CargoOption_Delete)]
  public ActionResult<Result> DeleteSubCategory([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteSubCategory(id);
    _logService.AdminLog(res, adminId, "SubCategory.Delete", id);
    return res.ToActionResult();
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.Category_Update)]
  public ActionResult<Result> EnableOrDisableSubCategory([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableOrDisableSubCategory(id);
    _logService.AdminLog(res, adminId, "SubCategory.Update", id);
    return res.ToActionResult();
  }
}