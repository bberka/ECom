namespace ECom.Shared.DTOs;

public class AddCollectionRequest : BaseAuthenticatedRequest
{
    [MinLength(3)]
    public string Name { get; set; }
}