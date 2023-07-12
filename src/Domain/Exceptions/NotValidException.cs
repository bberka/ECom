namespace ECom.Domain.Exceptions;

public class NotValidException : CustomException
{
  public NotValidException(string entityName) : base(entityName) {
  }
}