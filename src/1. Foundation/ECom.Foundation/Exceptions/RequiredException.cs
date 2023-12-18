namespace ECom.Foundation.Exceptions;

public class RequiredException : CustomException
{
  public RequiredException(string propertyName) : base(propertyName) { }
}