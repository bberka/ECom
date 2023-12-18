namespace ECom.Foundation.Exceptions;

public class AlreadyExistException : CustomException
{
  public AlreadyExistException(string propertyName) : base(propertyName) { }
}