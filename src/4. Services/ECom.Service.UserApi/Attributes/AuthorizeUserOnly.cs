namespace ECom.Service.UserApi.Attributes;

public sealed class AuthorizeUserOnly : AuthorizeAttribute
{
  public AuthorizeUserOnly() {
    Policy = EComClaimTypes.UserPolicy;
  }
}