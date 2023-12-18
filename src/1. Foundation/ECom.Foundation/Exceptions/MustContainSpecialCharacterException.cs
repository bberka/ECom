namespace ECom.Foundation.Exceptions;

public class MustContainSpecialCharacterException : CustomException
{
  public MustContainSpecialCharacterException(string propertyName) : base(propertyName) { }
}