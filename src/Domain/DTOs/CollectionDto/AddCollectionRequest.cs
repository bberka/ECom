namespace ECom.Domain.DTOs.CollectionDto;

public class AddCollectionRequest : BaseAuthenticatedRequest
{
  [MinLength(3)]
  public string Name { get; set; }
}