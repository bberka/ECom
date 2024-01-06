using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_StockChange_Add
{
  /// <summary>
  ///   0: Decrease
  ///   1: New
  /// </summary>
  public StockChangeType Type { get; set; }

  public int Count { get; set; }
  public int Cost { get; set; }
  public Guid ProductId { get; set; }
  public Guid SupplierId { get; set; }
  public string? Reason { get; set; }
}