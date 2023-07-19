namespace ECom.Shared.DTOs.ProductDto;

public class ListProductsRequest
{
  public int Page { get; set; }
  public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
}