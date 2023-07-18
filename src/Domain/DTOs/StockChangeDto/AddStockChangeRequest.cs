namespace ECom.Domain.DTOs.StockChangeDto;

public class AddStockChangeRequest
{
  /// <summary>
  ///   0: Decrease
  ///   1: Create
  /// </summary>
  public bool Type { get; set; }

  public int Count { get; set; }
  public int Cost { get; set; }
  public int ProductId { get; set; }
  public int SupplierId { get; set; }
  public string? Reason { get; set; }
}