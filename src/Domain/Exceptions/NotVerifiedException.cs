namespace ECom.Domain.Exceptions;

public class NotVerifiedException : CustomException
{
  public NotVerifiedException(string propertyName) : base(propertyName) {
  }
}