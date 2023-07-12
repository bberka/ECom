namespace ECom.Domain.ValueObjects;

public class ErrorResponse
{
  public List<ErrorModel> Errors { get; set; } = new();
}