namespace ECom.Domain.Exceptions;

public class RequiredException : CustomException
{
  public RequiredException(string propertyName) : base(propertyName) {
  }
}