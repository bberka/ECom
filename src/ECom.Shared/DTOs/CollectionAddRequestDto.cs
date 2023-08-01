namespace ECom.Shared.DTOs;

public class CollectionAddRequestDto : BaseAuthenticatedRequest
{
    [MinLength(3)]
    public string Name { get; set; }
}