using ECom.Domain;

namespace ECom.Application.Services;

public class SupplierService : ISupplierService
{
  private readonly IUnitOfWork _unitOfWork;

  public SupplierService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Supplier> ListSuppliers() {
    return _unitOfWork.SupplierRepository
      .Get()
      .OrderByDescending(x => x.RegisterDate)
      .ToList();
  }

  public bool Exists(int id) {
    return _unitOfWork.SupplierRepository.Any(x => x.Id == id);
  }

  public CustomResult<Supplier> Get(int id) {
    var supplier = _unitOfWork.SupplierRepository.GetById(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    return supplier;
  }

  public CustomResult Update(Supplier supplier) {
    var exist = Exists(supplier.Id);
    if (!exist) return DomainResult.NotFound(nameof(Supplier));
    _unitOfWork.SupplierRepository.Update(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Update));
    return DomainResult.OkUpdated(nameof(Supplier));
  }

  public CustomResult Delete(int id) {
    var supplier = _unitOfWork.SupplierRepository.GetById(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    _unitOfWork.SupplierRepository.Delete(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError("DeleteSupplier");
    return DomainResult.OkDeleted("Supplier");
  }
}