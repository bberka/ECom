namespace ECom.Shared.DTOs.StockChangeDto;

public class AddStockChangeRequest
{
  /// <summary>
  ///   0: Decrease
  ///   1: Create
  /// </summary>
  public StockChangeType Type { get; set; }

  public int Count { get; set; }
  public int Cost { get; set; }
  public Guid ProductId { get; set; }
  public Guid SupplierId { get; set; }
  public string? Reason { get; set; }
}