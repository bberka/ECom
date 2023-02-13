using ECom.Domain.DTOs.StockChangeDTOs;
using ECom.Domain.Results;

namespace ECom.Application.Services;

public class StockChangeService : IStockChangeService
{
    private readonly IEfEntityRepository<StockChange> _stockChangeRepo;
    private readonly ISupplierService _supplierService;
    private readonly IProductService _productService;

    public StockChangeService(
        IEfEntityRepository<StockChange> stockChangeRepo,
        ISupplierService supplierService,
        IProductService productService)
    {
        _stockChangeRepo = stockChangeRepo;
        _supplierService = supplierService;
        _productService = productService;
    }
    public Result Add(AddStockChangeRequest model)
    {
        var productExist = _productService.Exists(model.ProductId);
        if (!productExist) return DomainResult.Product.NotFoundResult(1);
        var supplierExist = _supplierService.Exists(model.SupplierId);
        if(!supplierExist) return DomainResult.Supplier.NotFoundResult(2);
        var stockChange = new StockChange()
        {
            ProductId = model.ProductId,
            Cost = model.Cost,
            Count = model.Count,
            RegisterDate = DateTime.Now,
            SupplierId = model.SupplierId,
            Type = model.Type,
        };
        var res = _stockChangeRepo.Add(stockChange);
        if (!res) return DomainResult.DbInternalErrorResult(3);
        return DomainResult.StockChange.AddSuccessResult();
    }

    public Result DecreaseStockOnOrder(int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public long CalculateProductStock(int productId)
    {
        throw new NotImplementedException();
    }

    public ResultData<List<StockChange>> GetProductStockChanges(int productId)
    {
        throw new NotImplementedException();
    }

    public ResultData<List<StockChange>> GetSupplierStockChanges(int supplierId)
    {
        throw new NotImplementedException();
    }
}