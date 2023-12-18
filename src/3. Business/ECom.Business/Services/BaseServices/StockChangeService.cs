namespace ECom.Business.Services.BaseServices;

public class StockChangeService : IAdminStockService
{
  private readonly IProductService _productService;
  private readonly IAdminSupplierService _supplierService;
  private readonly IUnitOfWork _unitOfWork;

  public StockChangeService(
    IUnitOfWork unitOfWork,
    IAdminSupplierService supplierService,
    IProductService productService) {
    _unitOfWork = unitOfWork;
    _supplierService = supplierService;
    _productService = productService;
  }

  public Result AddStockChange(Request_StockChange_Add model) {
    var productExists = _unitOfWork.Products.Any(x => x.Id == model.ProductId);
    var productExist = _productService.Exists(model.ProductId);
    if (!productExist) return DefResult.NotFound(nameof(Product));
    var supplierExist = _unitOfWork.Suppliers.Any(x => x.Id == model.SupplierId);
    if (!supplierExist) return DefResult.NotFound(nameof(Supplier));
    var stockChange = new StockChange {
      ProductId = model.ProductId,
      Cost = model.Cost,
      Count = model.Count,
      RegisterDate = DateTime.Now,
      SupplierId = model.SupplierId,
      Type = model.Type
    };
    _unitOfWork.StockChanges.Add(stockChange);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddStockChange));
    return DefResult.OkAdded(nameof(StockChange));
  }

  public Result DecreaseStockOnOrder(int productId, int quantity) {
    throw new NotImplementedException();
  }

  public long CalculateProductStock(int productId) {
    throw new NotImplementedException();
  }

  public Result<List<StockChange>> GetProductStockChanges(int productId) {
    throw new NotImplementedException();
  }

  public Result<List<StockChange>> GetSupplierStockChanges(int supplierId) {
    throw new NotImplementedException();
  }
}