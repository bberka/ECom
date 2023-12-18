namespace ECom.Foundation.Exceptions;

public class AlreadyInUseException : CustomException
{
  public AlreadyInUseException(string propertyName) : base(propertyName) { }
}