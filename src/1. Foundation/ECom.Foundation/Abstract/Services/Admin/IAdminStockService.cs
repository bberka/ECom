using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminStockService
{
  Result AddStockChange(Request_StockChange_Add model);
  Result DecreaseStockOnOrder(int productId, int quantity);
  long CalculateProductStock(int productId);
  Result<List<StockChange>> GetProductStockChanges(int productId);
  Result<List<StockChange>> GetSupplierStockChanges(int supplierId);
}