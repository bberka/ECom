namespace ECom.Foundation.Exceptions;

public class ExpiredException : CustomException
{
  public ExpiredException(string entityName) : base(entityName) { }
}