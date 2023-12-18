namespace ECom.Foundation.DTOs.Request;

public class Request_Collection_Add : BaseAuthenticatedRequest
{
  [MinLength(3)]
  public string Name { get; set; }
}