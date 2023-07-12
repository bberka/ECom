namespace ECom.Domain.DTOs.CollectionDTOs;

public class AddCollectionRequest : AuthRequestModelBase
{
  [MinLength(3)]
  public string Name { get; set; }
}