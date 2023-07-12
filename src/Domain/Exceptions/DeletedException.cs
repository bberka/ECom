namespace ECom.Domain.Exceptions;

public class DeletedException : CustomException
{
  public DeletedException(string entityName) : base(entityName) {
  }
}