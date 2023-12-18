namespace ECom.Foundation.Exceptions;

public class CanNotContainSpaceException : CustomException
{
  public CanNotContainSpaceException(string propertyName) : base(propertyName) { }
}