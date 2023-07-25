using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminStockService
{
    CustomResult AddStockChange(AddStockChangeRequest model);
    CustomResult DecreaseStockOnOrder(int productId, int quantity);
    long CalculateProductStock(int productId);
    CustomResult<List<StockChange>> GetProductStockChanges(int productId);
    CustomResult<List<StockChange>> GetSupplierStockChanges(int supplierId);
}