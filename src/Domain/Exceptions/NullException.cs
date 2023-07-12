namespace ECom.Domain.Exceptions;

public class NullException : CustomException
{
  public NullException(string name) : base(name) {
  }
}