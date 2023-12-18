namespace ECom.Service.AdminApi.Attributes;

public sealed class AuthorizeAdminOnly : AuthorizeAttribute
{
  public AuthorizeAdminOnly() {
    Policy = EComClaimTypes.AdminPolicy;
  }
}