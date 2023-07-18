namespace ECom.Domain.DTOs.CollectionDto;

public class UpdateCollectionRequest : BaseAuthenticatedRequest
{
  public int CollectionId { get; set; }
  public string CollectionName { get; set; }
}