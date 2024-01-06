using ECom.Foundation.Static;

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
    if (supplier is null)
      return DomResults.x_is_not_found("supplier");
    return supplier;
  }

  public Result UpdateSupplier(Supplier supplier) {
    var exists = _unitOfWork.Suppliers.Any(x => x.Id == supplier.Id);
    if (!exists)
      return DomResults.x_is_not_found("supplier");
    _unitOfWork.Suppliers.Update(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateSupplier));
    return DomResults.x_is_updated_successfully("supplier");
  }

  public Result DeleteSupplier(int id) {
    var supplier = _unitOfWork.Suppliers.Find(id);
    if (supplier is null)
      return DomResults.x_is_not_found("supplier");
    _unitOfWork.Suppliers.Remove(supplier);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error("supplier");
    return DomResults.x_is_deleted_successfully("supplier");
  }
}