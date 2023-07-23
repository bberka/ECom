using ECom.Shared.Constants;

namespace ECom.Application.Attributes;

public class AdminAuthorize : AuthorizeAttribute
{
  public AdminAuthorize(RoleType minimumRoleAccess) {
    var roleNum = (int)minimumRoleAccess;
    var aboveRoles = Enum.GetValues<RoleType>().Where(x => (int)x > roleNum).Select(x => x.ToString());
    Roles = string.Join(",", aboveRoles);
  }
}