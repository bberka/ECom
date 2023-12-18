namespace ECom.Foundation.Exceptions;

public class ValidationErrorException : CustomException
{
  public ValidationErrorException(string propertyname, string message) : base($"{propertyname}:{message}") { }
}