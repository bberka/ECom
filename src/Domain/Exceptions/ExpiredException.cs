namespace ECom.Domain.Exceptions;

public class ExpiredException : CustomException
{
  public ExpiredException(string entityName) : base(entityName) {
  }
}