using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public class StockChangeService : IAdminStockService
{
    private readonly IProductService _productService;
    private readonly IAdminSupplierService _supplierService;
    private readonly IUnitOfWork _unitOfWork;

    public StockChangeService(
      IUnitOfWork unitOfWork,
      IAdminSupplierService supplierService,
      IProductService productService)
    {
        _unitOfWork = unitOfWork;
        _supplierService = supplierService;
        _productService = productService;
    }

    public CustomResult AddStockChange(AddStockChangeRequest model)
    {
        var productExists = _unitOfWork.ProductRepository.Any(x => x.Id == model.ProductId);
        var productExist = _productService.Exists(model.ProductId);
        if (!productExist) return DomainResult.NotFound(nameof(Product));
        var supplierExist = _unitOfWork.SupplierRepository.Any(x => x.Id == model.SupplierId);
        if (!supplierExist) return DomainResult.NotFound(nameof(Supplier));
        var stockChange = new StockChange
        {
            ProductId = model.ProductId,
            Cost = model.Cost,
            Count = model.Count,
            RegisterDate = DateTime.Now,
            SupplierId = model.SupplierId,
            Type = model.Type
        };
        _unitOfWork.StockChangeRepository.Add(stockChange);
        var res = _unitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(AddStockChange));
        return DomainResult.OkAdded(nameof(StockChange));
    }

    public CustomResult DecreaseStockOnOrder(int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public long CalculateProductStock(int productId)
    {
        throw new NotImplementedException();
    }

    public CustomResult<List<StockChange>> GetProductStockChanges(int productId)
    {
        throw new NotImplementedException();
    }

    public CustomResult<List<StockChange>> GetSupplierStockChanges(int supplierId)
    {
        throw new NotImplementedException();
    }
}