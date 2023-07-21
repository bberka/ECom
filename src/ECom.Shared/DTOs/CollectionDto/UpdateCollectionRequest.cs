namespace ECom.Shared.DTOs.CollectionDto;

public class UpdateCollectionRequest : BaseAuthenticatedRequest
{
  public Guid CollectionId { get; set; }
  public string CollectionName { get; set; }
}