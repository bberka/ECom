namespace ECom.Foundation.DTOs.Request;

public class Request_Collection_Update : BaseAuthenticatedRequest
{
  public Guid CollectionId { get; set; }
  public string CollectionName { get; set; }
}