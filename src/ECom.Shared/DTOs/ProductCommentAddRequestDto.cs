namespace ECom.Shared.DTOs;

public class ProductCommentAddRequestDto : BaseAuthenticatedRequest
{
    public string Comment { get; set; }

    public byte Star { get; set; }

    public Guid ProductId { get; set; }
}