namespace ECom.WebApi.Controllers.AdminControllers;

public class RoleController : BaseAdminController
{
  private readonly IRoleService _roleService;

  public RoleController(IRoleService roleService) {
    _roleService = roleService;
  }

  [HttpGet]
  public ActionResult<List<Role>> ListRolesWithPermissions() {
    return _roleService.GetRolesWithPermissions();
  }
}