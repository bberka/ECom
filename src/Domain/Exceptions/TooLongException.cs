namespace ECom.Domain.Exceptions;

public class TooLongException : CustomException
{
  public TooLongException(string propertyName, int maxLimit) : base($"{propertyName}:{maxLimit}") {
  }
}