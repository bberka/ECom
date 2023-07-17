namespace ECom.Domain.DTOs.CollectionDTOs;

public class AddCollectionRequest : BaseAuthenticatedRequest
{
  [MinLength(3)]
  public string Name { get; set; }
}