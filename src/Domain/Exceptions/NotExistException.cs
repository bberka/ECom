namespace ECom.Domain.Exceptions;

public class NotExistException : CustomException
{
  public NotExistException(string entityName) : base(entityName) {
  }
}