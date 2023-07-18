namespace ECom.Domain.DTOs.ProductDto;

public class AddProductCommentRequest : BaseAuthenticatedRequest
{
  public string Comment { get; set; }

  public byte Star { get; set; }

  public int ProductId { get; set; }
}