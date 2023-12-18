namespace ECom.Business.Attributes;

public sealed class AuthorizeUserOnly : AuthorizeAttribute
{
  public AuthorizeUserOnly() {
    Policy = EComClaimTypes.UserPolicy;
  }
}