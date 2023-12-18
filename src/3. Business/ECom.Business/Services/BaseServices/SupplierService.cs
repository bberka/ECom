namespace ECom.Business.Services.BaseServices;

public class SupplierService : IAdminSupplierService
{
  private readonly IUnitOfWork _unitOfWork;

  public SupplierService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Supplier> GetSuppliers() {
    return _unitOfWork.Suppliers
                      .OrderByDescending(x => x.RegisterDate)
                      .ToList();
  }

  public Result<Supplier> GetSupplier(int id) {
    var supplier = _unitOfWork.Suppliers.Find(id);
    if (supplier is null) return DefResult.NotFound(nameof(Supplier));
    return supplier;
  }

  public Result UpdateSupplier(Supplier supplier) {
    var exists = _unitOfWork.Suppliers.Any(x => x.Id == supplier.Id);
    if (!exists) return DefResult.NotFound(nameof(Supplier));
    _unitOfWork.Suppliers.Update(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateSupplier));
    return DefResult.OkUpdated(nameof(Supplier));
  }

  public Result DeleteSupplier(int id) {
    var supplier = _unitOfWork.Suppliers.Find(id);
    if (supplier is null) return DefResult.NotFound(nameof(Supplier));
    _unitOfWork.Suppliers.Remove(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError("DeleteSupplier");
    return DefResult.OkDeleted("Supplier");
  }
}