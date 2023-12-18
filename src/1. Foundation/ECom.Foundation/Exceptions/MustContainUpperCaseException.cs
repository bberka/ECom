namespace ECom.Foundation.Exceptions;

public class MustContainUpperCaseException : CustomException
{
  public MustContainUpperCaseException(string propertyName) : base(propertyName) { }
}