using ECom.Foundation.Enum;

namespace ECom.Foundation.Exceptions;

public class NotAuthorizedException : CustomException
{
  public NotAuthorizedException(AuthType requiredAuthenticationType) : base(requiredAuthenticationType) { }
}