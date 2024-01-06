using ECom.Foundation.Static;

namespace ECom.Service.AdminApi.Attributes;

public sealed class AuthorizeAdminOnly : AuthorizeAttribute
{
  public AuthorizeAdminOnly() {
    Policy = DomClaimTypes.AdminPolicy;
  }
}