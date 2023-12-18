namespace ECom.Foundation.Exceptions;

public class DeletedException : CustomException
{
  public DeletedException(string entityName) : base(entityName) { }
}