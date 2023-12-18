namespace ECom.Foundation.Exceptions;

public class WrongDataException : CustomException
{
  public WrongDataException(string name) : base(name) { }
}