namespace ECom.Domain.Exceptions;

public class CustomException : Exception
{
  public CustomException(object? message) : base(message?.ToString()) {
  }
}