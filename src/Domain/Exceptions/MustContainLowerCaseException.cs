namespace ECom.Domain.Exceptions;

public class MustContainLowerCaseException : CustomException
{
  public MustContainLowerCaseException(string propertyName) : base(propertyName) {
  }
}