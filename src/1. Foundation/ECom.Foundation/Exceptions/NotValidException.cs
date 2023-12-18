namespace ECom.Foundation.Exceptions;

public class NotValidException : CustomException
{
  public NotValidException(string entityName) : base(entityName) { }
}