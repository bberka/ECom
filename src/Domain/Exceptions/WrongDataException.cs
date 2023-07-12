namespace ECom.Domain.Exceptions;

public class WrongDataException : CustomException
{
  public WrongDataException(string name) : base(name) {
  }
}