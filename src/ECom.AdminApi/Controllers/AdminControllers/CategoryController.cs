using ECom.Domain.DTOs.CategoryDTOs;
using ECom.WebApi.Controllers;

namespace ECom.AdminApi.Controllers.AdminControllers;

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
  [RequirePermission(AdminOperationType.CategoryAdd)]
  public ActionResult<CustomResult> AddCategory([FromBody] AddCategoryRequest model) {
    var res = _categoryService.AddCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Category.Add", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryAdd)]
  public ActionResult<CustomResult> AddSubCategory([FromBody] AddSubCategoryRequest model) {
    var res = _categoryService.AddSubCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "SubCategory.Add", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryUpdate)]
  public ActionResult<CustomResult> Update([FromBody] UpdateCategoryRequest model) {
    var res = _categoryService.UpdateCategory(model);
    _logService.AdminLog(res, model.AuthenticatedAdminId, "Category.Update", model.ToJsonString());
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.CategoryDelete)]
  public ActionResult<CustomResult> Delete([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteCategory(id);
    _logService.AdminLog(res, adminId, "Category.Delete", id);
    return res.ToActionResult();
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.CategoryDisable)]
  public ActionResult<CustomResult> Disable([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DisableCategory(id);
    _logService.AdminLog(res, adminId, "Category.Disable", id);
    return res.ToActionResult();
  }
  [HttpPut]
  [RequirePermission(AdminOperationType.CategoryEnable)]
  public ActionResult<CustomResult> Enable([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableCategory(id);
    _logService.AdminLog(res, adminId, "Category.Enable", id);
    return res.ToActionResult();
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.CategoryUpdate)]
  public ActionResult<CustomResult> UpdateSubCategory([FromBody] SubCategory category) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.UpdateSubCategory(category);
    _logService.AdminLog(res, adminId, "SubCategory.Update", category.ToJsonString());
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.CargoOptionDelete)]
  public ActionResult<CustomResult> DeleteSubCategory([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.DeleteSubCategory(id);
    _logService.AdminLog(res, adminId, "SubCategory.Delete", id);
    return res.ToActionResult();
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.SubCategoryEnable)]
  public ActionResult<CustomResult> EnableSubCategory([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableSubCategory(id);
    _logService.AdminLog(res, adminId, "SubCategory.Enable", id);
    return res.ToActionResult();
  }
  [HttpPut]
  [RequirePermission(AdminOperationType.SubCategoryDisable)]
  public ActionResult<CustomResult> DisableSubCategory([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _categoryService.EnableSubCategory(id);
    _logService.AdminLog(res, adminId, "SubCategory.Disable", id);
    return res.ToActionResult();
  }
}