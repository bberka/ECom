namespace ECom.Domain.Exceptions;

public class TooShortException : CustomException
{
  public TooShortException(string propertyName, int minLimit) : base($"{propertyName}:{minLimit}") {
  }
}