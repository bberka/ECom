namespace ECom.Domain.DTOs;

public class NameRequest : BaseAuthenticatedRequest
{
  public string Name { get; set; }
}