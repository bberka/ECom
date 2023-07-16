using ECom.Domain.DTOs.StockChangeDTOs;

namespace ECom.Domain.Abstract;

public interface IStockChangeService
{
  CustomResult AddStockChange(AddStockChangeRequest model);
  CustomResult DecreaseStockOnOrder(int productId, int quantity);
  long CalculateProductStock(int productId);
  CustomResult<List<StockChange>> GetProductStockChanges(int productId);
  CustomResult<List<StockChange>> GetSupplierStockChanges(int supplierId);
}