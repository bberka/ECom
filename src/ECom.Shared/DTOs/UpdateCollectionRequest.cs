namespace ECom.Shared.DTOs;

public class UpdateCollectionRequest : BaseAuthenticatedRequest
{
    public Guid CollectionId { get; set; }
    public string CollectionName { get; set; }
}