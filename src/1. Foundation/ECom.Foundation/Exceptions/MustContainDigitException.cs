namespace ECom.Foundation.Exceptions;

public class MustContainDigitException : CustomException
{
  public MustContainDigitException(string propertyName) : base(propertyName) { }
}