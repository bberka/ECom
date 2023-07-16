namespace ECom.AdminApi.Endpoints.RoleEndpoints;

[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Role>>
{
  private readonly IRoleService _roleService;

  public List(IRoleService roleService) {
    _roleService = roleService;
  }

  [HttpGet]
  [EndpointSwaggerOperation(typeof(List),"Gets roles with permissions included")]
  public override List<Role> Handle()
  {
    return _roleService.GetRolesWithPermissions();
  }
}