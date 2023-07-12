using ECom.Domain.DTOs.StockChangeDTOs;

namespace ECom.Domain.Abstract;

public interface IStockChangeService
{
  Result Add(AddStockChangeRequest model);

  Result DecreaseStockOnOrder(int productId, int quantity);
  long CalculateProductStock(int productId);

  ResultData<List<StockChange>> GetProductStockChanges(int productId);
  ResultData<List<StockChange>> GetSupplierStockChanges(int supplierId);
}