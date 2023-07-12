namespace ECom.Domain.DTOs.CollectionDTOs;

public class UpdateCollectionRequest : AuthRequestModelBase
{
  public int CollectionId { get; set; }
  public string CollectionName { get; set; }
}