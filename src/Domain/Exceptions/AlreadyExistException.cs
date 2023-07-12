namespace ECom.Domain.Exceptions;

public class AlreadyExistException : CustomException
{
  public AlreadyExistException(string propertyName) : base(propertyName) {
  }
}