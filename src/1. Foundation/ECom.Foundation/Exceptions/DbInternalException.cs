namespace ECom.Foundation.Exceptions;

public class DbInternalException : CustomException
{
  public DbInternalException(string actionName) : base(actionName) { }
}