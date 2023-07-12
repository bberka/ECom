namespace ECom.Domain.Exceptions;

public class NotAuthorizedException : CustomException
{
  public NotAuthorizedException(AuthType requiredAuthenticationType) : base(requiredAuthenticationType) {
  }
}