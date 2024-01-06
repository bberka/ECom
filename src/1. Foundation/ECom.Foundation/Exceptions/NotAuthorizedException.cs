using ECom.Foundation.Static;

namespace ECom.Foundation.Exceptions;

public class NotAuthorizedException : CustomException
{
  public NotAuthorizedException(AuthType requiredAuthenticationType) : base(requiredAuthenticationType) { }
}