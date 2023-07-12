using ECom.Domain.DTOs.StockChangeDTOs;

namespace ECom.Application.Services;

public class StockChangeService : IStockChangeService
{
  private readonly IProductService _productService;
  private readonly ISupplierService _supplierService;
  private readonly IUnitOfWork _unitOfWork;

  public StockChangeService(
    IUnitOfWork unitOfWork,
    ISupplierService supplierService,
    IProductService productService) {
    _unitOfWork = unitOfWork;
    _supplierService = supplierService;
    _productService = productService;
  }

  public Result Add(AddStockChangeRequest model) {
    var productExist = _productService.Exists(model.ProductId);
    if (!productExist) return DomainResult.Product.NotFoundResult();
    var supplierExist = _supplierService.Exists(model.SupplierId);
    if (!supplierExist) return DomainResult.Supplier.NotFoundResult();
    var stockChange = new StockChange {
      ProductId = model.ProductId,
      Cost = model.Cost,
      Count = model.Count,
      RegisterDate = DateTime.Now,
      SupplierId = model.SupplierId,
      Type = model.Type
    };
    _unitOfWork.StockChangeRepository.Insert(stockChange);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.StockChange.AddSuccessResult();
  }

  public Result DecreaseStockOnOrder(int productId, int quantity) {
    throw new NotImplementedException();
  }

  public long CalculateProductStock(int productId) {
    throw new NotImplementedException();
  }

  public ResultData<List<StockChange>> GetProductStockChanges(int productId) {
    throw new NotImplementedException();
  }

  public ResultData<List<StockChange>> GetSupplierStockChanges(int supplierId) {
    throw new NotImplementedException();
  }
}