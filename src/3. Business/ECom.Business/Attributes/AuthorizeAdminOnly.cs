namespace ECom.Business.Attributes;

public sealed class AuthorizeAdminOnly : AuthorizeAttribute
{
  public AuthorizeAdminOnly() {
    Policy = EComClaimTypes.AdminPolicy;
  }
}