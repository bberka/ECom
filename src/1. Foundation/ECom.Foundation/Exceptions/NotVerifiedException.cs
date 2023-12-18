namespace ECom.Foundation.Exceptions;

public class NotVerifiedException : CustomException
{
  public NotVerifiedException(string propertyName) : base(propertyName) { }
}