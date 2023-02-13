using ECom.Domain.Results;

namespace ECom.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly IEfEntityRepository<Supplier> _supplierRepo;

    public SupplierService(
        IEfEntityRepository<Supplier> supplierRepo)
    {
        _supplierRepo = supplierRepo;
    }
    public List<Supplier> ListSuppliers()
    {
        return _supplierRepo
            .Get()
            .OrderByDescending(x => x.RegisterDate)
            .ToList();
    }

    public bool Exists(int id)
    {
        return _supplierRepo.Any(x => x.Id == id);
    }

    public ResultData<Supplier> Get(int id)
    {
        var supplier = _supplierRepo.Find(id);
        if (supplier is null) return DomainResult.Supplier.NotFoundResult(1);
        return supplier;
    }

    public Result Update(Supplier supplier)
    {
        var exist = Exists(supplier.Id);
        if (!exist) return DomainResult.Supplier.NotFoundResult(1);
        var res = _supplierRepo.Update(supplier);
        if (!res) return DomainResult.DbInternalErrorResult(2);
        return DomainResult.Supplier.UpdateSuccessResult();
    }

    public Result Delete(int id)
    {
        var supplier = _supplierRepo.Find(id);
        if (supplier is null) return DomainResult.Supplier.NotFoundResult(1);
        var res = _supplierRepo.Delete(supplier);
        if (!res) return DomainResult.DbInternalErrorResult(2);
        return DomainResult.Supplier.DeleteSuccessResult();
    }
}