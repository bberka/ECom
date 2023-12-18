using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs.Request;

public class Request_Product_List
{
  public int Page { get; set; }
  public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
}