using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class SupplierService : IAdminSupplierService
{
  protected readonly IUnitOfWork UnitOfWork;

  protected SupplierService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public List<Supplier> GetSuppliers() {
    return UnitOfWork.SupplierRepository
      
      .OrderByDescending(x => x.RegisterDate)
      .ToList();
  }

  public CustomResult<Supplier> GetSupplier(int id) {
    var supplier = UnitOfWork.SupplierRepository.Find(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    return supplier;
  }

  public CustomResult UpdateSupplier(Supplier supplier) {
    var exists = UnitOfWork.SupplierRepository.Any(x => x.Id == supplier.Id);
    if (!exists) return DomainResult.NotFound(nameof(Supplier));
    UnitOfWork.SupplierRepository.Update(supplier);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSupplier));
    return DomainResult.OkUpdated(nameof(Supplier));
  }

  public CustomResult DeleteSupplier(int id) {
    var supplier = UnitOfWork.SupplierRepository.Find(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    UnitOfWork.SupplierRepository.Remove(supplier);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError("DeleteSupplier");
    return DomainResult.OkDeleted("Supplier");
  }
}