namespace ECom.Domain.Exceptions;

public class MustContainSpecialCharacterException : CustomException
{
  public MustContainSpecialCharacterException(string propertyName) : base(propertyName) {
  }
}