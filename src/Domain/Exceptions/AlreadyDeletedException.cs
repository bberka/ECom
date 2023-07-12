namespace ECom.Domain.Exceptions;

public class AlreadyDeletedException : CustomException
{
  public AlreadyDeletedException(string propertyName) : base(propertyName) {
  }
}