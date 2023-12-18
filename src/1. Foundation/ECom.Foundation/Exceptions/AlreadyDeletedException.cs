namespace ECom.Foundation.Exceptions;

public class AlreadyDeletedException : CustomException
{
  public AlreadyDeletedException(string propertyName) : base(propertyName) { }
}