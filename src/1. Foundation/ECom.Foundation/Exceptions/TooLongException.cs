namespace ECom.Foundation.Exceptions;

public class TooLongException : CustomException
{
  public TooLongException(string propertyName, int maxLimit) : base($"{propertyName}:{maxLimit}") { }
}