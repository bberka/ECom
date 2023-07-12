namespace ECom.Domain.Exceptions;

public class ValidationErrorException : CustomException
{
  public ValidationErrorException(string propertyname, string message) : base($"{propertyname}:{message}") {
  }
}