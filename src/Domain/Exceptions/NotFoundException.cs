namespace ECom.Domain.Exceptions;

public class NotFoundException : CustomException
{
  public NotFoundException(string entityName) : base(entityName) {
  }
}