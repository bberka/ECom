namespace ECom.Foundation.Exceptions;

public class CanNotBeUsedException : CustomException
{
  public CanNotBeUsedException(string name) : base(name) { }
}