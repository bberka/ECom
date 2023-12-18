namespace ECom.Service.AdminApi.Attributes;

public class AuthorizeAdminPermission : AuthorizeAttribute
{
  //public AdminAuthorize(RoleType minimumRoleAccess) {
  //  var roleNum = (int)minimumRoleAccess;
  //  var aboveRoles = Enum.GetValues<RoleType>().Where(x => (int)x > roleNum).Select(x => x.ToString());
  //  Roles = string.Join(",", aboveRoles);
  //}
  public AuthorizeAdminPermission(AdminPermissionType permission) {
    Policy = permission.ToString();
  }
}