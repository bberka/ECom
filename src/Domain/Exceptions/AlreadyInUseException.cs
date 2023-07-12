namespace ECom.Domain.Exceptions;

public class AlreadyInUseException : CustomException
{
  public AlreadyInUseException(string propertyName) : base(propertyName) {
  }
}