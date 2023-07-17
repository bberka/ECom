namespace ECom.Domain.DTOs.CollectionDTOs;

public class UpdateCollectionRequest : BaseAuthenticatedRequest
{
  public int CollectionId { get; set; }
  public string CollectionName { get; set; }
}